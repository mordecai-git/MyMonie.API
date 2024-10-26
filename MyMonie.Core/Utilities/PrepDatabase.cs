// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyMonie.Models.App;
using MyMonie.Models.Constants;
using Serilog;
using System;
using System.Linq;

namespace MyMonie.Core.Utilities;
public static class PrepDatabase
{
    public static void InitializeDatabase(this IApplicationBuilder app, bool isDevelopment)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<MyMonieContext>(), isDevelopment);
    }

    private static void SeedData(MyMonieContext context, bool isDevelopment)
    {
        // Ensure to apply pending migrations when deployed
        if (!isDevelopment)
        {
            Log.Information("--> Attempting to apply pending migrations...");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "--> An error occurred while applying pending migrations");
            }
        }

        // create Default Transaction Types
        if (!context.TransactionTypes.Any())
        {
            Log.Information("--> Seeding Transaction Type Data...");

            // reset the identity count
            context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT ('FieldTypes', RESEED, 1)");
            context.TransactionTypes.AddRange(
                new TransactionType { Name = nameof(TransactionTypes.Income) },
                new TransactionType { Name = nameof(TransactionTypes.Expense) },
                new TransactionType { Name = nameof(TransactionTypes.Transfer) },
                new TransactionType { Name = nameof(TransactionTypes.Loan) }
                );
        }

        // TODO: Define roles

        context.SaveChanges();
    }
}
