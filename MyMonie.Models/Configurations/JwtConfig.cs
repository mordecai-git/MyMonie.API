// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

namespace MyMonie.Models.Configurations;
public class JwtConfig
{
    public string Key { get; set; }
    public int ExpiresMinutes { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int RefreshExpireDays { get; set; }
    public string AllowedDomains { get; set; }
}
