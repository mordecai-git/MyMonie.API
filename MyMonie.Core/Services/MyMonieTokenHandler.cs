// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using LazyCache;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyMonie.Core.Models.Utilities;
using MyMonie.Core.Utilities;
using MyMonie.Models.App;
using MyMonie.Models.CacheKeys;
using MyMonie.Models.Configurations;
using MyMonie.Models.Utilities;
using MyMonie.Models.View.Users;
using Serilog;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyMonie.Core.Services;
public class MyMonieTokenHandler(IOptions<JwtConfig> JsonWebToken, MyMonieContext context, IAppCache cache)
{
    private readonly JwtConfig _JsonWebToken = JsonWebToken.Value;
    private readonly MyMonieContext _context = context ?? throw new ArgumentNullException(nameof(MyMonieContext));
    private readonly IAppCache _cache = cache ?? throw new ArgumentNullException(nameof(cache));

    public async Task<Result> GenerateJwtToken(User user)
    {
        DateTime expiryDate = DateTime.UtcNow.AddMinutes(_JsonWebToken.ExpiresMinutes);

        string token = await GenerateAccessToken(user, expiryDate);
        string refreshToken = await GenerateRefreshToken(user.Id);

        // store the token
        var encryptedToken = token.HashString();
        var login = await _context.Logins.FirstOrDefaultAsync(l => l.UserId == user.Id);
        if (login != null)
        {
            login.HashedToken = encryptedToken;
            login.ExpiryDateUtc = expiryDate;
            login.UpdatedById = user.Id;
            login.UpdatedOnUtc = DateTime.UtcNow;

            _context.Logins.Update(login);
        }
        else
        {
            login = new Login
            {
                UserId = user.Id,
                HashedToken = encryptedToken,
                ExpiryDateUtc = expiryDate,
                CreatedById = user.Id,
                CreatedOnUtc = DateTime.UtcNow
            };

            await _context.Logins.AddAsync(login);
        }
        await _context.SaveChangesAsync();

        // clear any previous token from cache
        _cache.Remove(CacheKeys.ValidateToken(user.Uid));

        var result = new AuthDataViewModel
        {
            User = user.Adapt<UserViewModel>(),
            Token = token,
            RefreshToken = refreshToken,
            ExpiryDateUtc = expiryDate
        };

        return new SuccessResult(result);
    }

    public async Task<Result> RefreshJwtToken(string refreshToken)
    {
        var refreshTokenObject = await _context.RefreshTokens
            .Include(r => r.User)
            .FirstOrDefaultAsync(r => r.Code == refreshToken);

        if (refreshTokenObject == null || refreshTokenObject.ExpiresOnUtc < DateTime.UtcNow)
            return new ErrorResult("User session expired, kindly log in again", StatusCodes.Status419AuthenticationTimeout);

        await InvalidateToken(refreshTokenObject.User.Uid);

        return await GenerateJwtToken(refreshTokenObject.User);
    }

    public async Task InvalidateToken(Guid uid)
    {
        var login = await _context.Logins
            .FirstOrDefaultAsync(l => l.User!.Uid == uid);

        if (login != null)
        {
            login.HashedToken = string.Empty;
            login.ExpiryDateUtc = DateTime.UtcNow;

            // clear the token from cache
            _cache.Remove(CacheKeys.ValidateToken(uid));

            _context.Logins.Update(login);
            await _context.SaveChangesAsync();
        }

        var refreshToken = await _context.RefreshTokens
            .FirstOrDefaultAsync(r => r.User.Uid == uid);

        if (refreshToken != null)
        {
            _context.Remove(refreshToken);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ValidateToken(Guid uid, string token)
    {
        try
        {
            string cacheKey = CacheKeys.ValidateToken(uid);
            var cachedData = _cache.Get<(string HashedToken, DateTime ExpiryDateUtc)>(cacheKey);

            DateTime now = DateTime.UtcNow;
            if (cachedData != default)
            {
                // Check if the cached token is expired
                if (now > cachedData.ExpiryDateUtc)
                {
                    // Token is expired, remove it from cache
                    _cache.Remove(cacheKey);
                    return false;
                }

                // Validate the token using the cached hashed token
                return cachedData.HashedToken.VerifyHashedString(token);
            }
            else
            {
                // Token not in cache, perform database lookup
                var login = await _context.Logins
                    .Where(l => l.User!.Uid == uid && l.ExpiryDateUtc > now)
                    .Select(l => new { l.HashedToken, l.ExpiryDateUtc })
                    .FirstOrDefaultAsync();

                if (login is null)
                    return false;

                // Cache the hashed token and its expiration time
                _cache.Add(cacheKey, (login.HashedToken, login.ExpiryDateUtc), login.ExpiryDateUtc - now);

                // Validate the token
                return login.HashedToken.VerifyHashedString(token);
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error validating token");
            return false;
        }
    }

    private async Task<string> GenerateAccessToken(User user, DateTime expiryDate)
    {
        var claimIdentity = new ClaimsIdentity();

        claimIdentity.AddClaims([new Claim("uid", user.Uid.ToString())]);
        claimIdentity.AddClaims([new Claim("sid", user.Id.ToString())]);
        claimIdentity.AddClaims([new Claim("name", $"{user.FirstName} {user.LastName}")]);

        var userRoles = await _context.UserRoles
            .Include(ur => ur.Role)
            .Where(ur => ur.UserId == user.Id)
            .Select(ur => ur.Role.Name)
            .ToListAsync();

        claimIdentity.AddClaims(userRoles.Select(role =>
            new Claim(ClaimTypes.Role, role)));

        byte[] key = Encoding.ASCII.GetBytes(_JsonWebToken.Key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = _JsonWebToken.Audience,
            Issuer = _JsonWebToken.Issuer,
            Subject = claimIdentity,
            Expires = expiryDate,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        string token = tokenHandler.WriteToken(securityToken);

        return token;
    }

    private async Task<string> GenerateRefreshToken(int userId)
    {
        // Create a byte array to store the random bytes
        byte[] randomNumber = new byte[64];

        // Generate a random characters
        using var rng = RandomNumberGenerator.Create();

        rng.GetBytes(randomNumber);

        string token = Convert.ToBase64String(randomNumber);

        // store the refresh token
        var refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(r => r.UserId == userId);
        if (refreshToken == null)
        {
            await _context.AddAsync(new RefreshToken
            {
                UserId = userId,
                Code = token,
                ExpiresOnUtc = DateTime.UtcNow.AddDays(_JsonWebToken.RefreshExpireDays),
                CreatedOnUtc = DateTime.UtcNow
            });
        }
        else
        {
            refreshToken.Code = token;
            refreshToken.ExpiresOnUtc = DateTime.UtcNow.AddDays(_JsonWebToken.RefreshExpireDays);
            refreshToken.UpdatedOnUtc = DateTime.UtcNow;
        }
        await _context.SaveChangesAsync();

        return token;
    }
}