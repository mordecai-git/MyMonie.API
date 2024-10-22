// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyMonie.Core.Interfaces;
using MyMonie.Core.Services;

namespace MyMonie.Core.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();

        //Mapster global Setting. This can also be overwritten per transform
        TypeAdapterConfig.GlobalSettings.Default
            .NameMatchingStrategy(NameMatchingStrategy.IgnoreCase)
            .IgnoreNullValues(true)
            .AddDestinationTransform((string x) => x.Trim())
            .AddDestinationTransform((string x) => x ?? "")
            .AddDestinationTransform(DestinationTransform.EmptyCollectionIfNull);

        services.TryAddScoped<IMyMonieTokenHandler, MyMonieTokenHandler>();

        return services;
    }
}