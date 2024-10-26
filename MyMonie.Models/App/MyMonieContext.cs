// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using MyMonie.Models.App.Converters;
using MyMonie.Models.Interfaces;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MyMonie.Models.App;

public partial class MyMonieContext(DbContextOptions<MyMonieContext> options) : DbContext(options)
{
    protected readonly IConfiguration Configuration;

    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<AccountGroup> AccountGroups { get; set; }
    public virtual DbSet<Budget> Budgets { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Channel> Channels { get; set; }
    public virtual DbSet<Code> Codes { get; set; }
    public virtual DbSet<Currency> Currencies { get; set; }
    public virtual DbSet<Document> Documents { get; set; }
    public virtual DbSet<Group> Groups { get; set; }
    public virtual DbSet<Loan> Loans { get; set; }
    public virtual DbSet<Login> Logins { get; set; }
    public virtual DbSet<LoanInterest> LoanInterests { get; set; }
    public virtual DbSet<LoanRepayment> LoanRepayments { get; set; }
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    public virtual DbSet<RepeatTransaction> RepeatTransactions { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }
    public virtual DbSet<TransactionQueue> TransactionQueues { get; set; }
    public virtual DbSet<TransactionType> TransactionTypes { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserGroup> UserGroups { get; set; }
    public virtual DbSet<UserSetting> UserSettings { get; set; }
    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("MyMonie");

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            // Apply default value for Uid in BaseAppModel
            if (typeof(BaseAppModel).IsAssignableFrom(entityType.ClrType))
            {
                builder.Entity(entityType.ClrType)
                    .Property(nameof(BaseAppModel.Uid))
                    .HasDefaultValueSql("(newid())");

                builder.Entity(entityType.ClrType)
                    .Property(nameof(BaseAppModel.CreatedOnUtc))
                    .HasDefaultValueSql("GETDATE()");
            }

            // Set the default delete behavior for all relationships
            foreach (var foreignKey in entityType.GetForeignKeys())
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;

            // Apply value converters to properties that have the ValueConverterAttribute
            foreach (var property in entityType.ClrType.GetProperties())
            {
                var converterAttribute = property.GetCustomAttribute<ValueConverterAttribute>();
                if (converterAttribute != null)
                {
                    var converterInstance = (ValueConverter)Activator.CreateInstance(converterAttribute.ConverterType);
                    builder.Entity(entityType.ClrType)
                        .Property(property.Name)
                        .HasConversion(converterInstance);
                }
            }

            /* 
             * Apply query filter for ISoftDeletable entities to remove soft deleted entities from all queries.
             * This is done by adding a query filter to all entities that implement the ISoftDeletable interface.
             * This filter can be removed when querying the entity by using the IgnoreQueryFilters() method.
             * E.g. context.Set<T>().IgnoreQueryFilters().ToList();
             */
            if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
            {
                var entityBuilder = builder.Entity(entityType.ClrType);

                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var filter = Expression.Lambda(
                    Expression.Equal(
                        Expression.Property(parameter, nameof(ISoftDeletable.IsDeleted)),
                        Expression.Constant(false)
                    ),
                    parameter
                );

                entityBuilder.HasQueryFilter(filter);

                // Create an index on the IsDeleted property
                entityBuilder.HasIndex(nameof(ISoftDeletable.IsDeleted));
            }
        }

        builder.Entity<Budget>(entity =>
        {
            entity.Property(e => e.Period).IsFixedLength();
        });

        builder.Entity<Code>(entity =>
        {
            entity.Property(e => e.CodeText).IsFixedLength();

            entity.HasQueryFilter(e => e.ExpiresOnUtc > DateTime.UtcNow || e.IsUsed);
        });

        builder.Entity<Currency>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        builder.Entity<Loan>(entity =>
        {
            entity.Property(e => e.LoanType).IsFixedLength();
            entity.Property(e => e.RepaymentInterval).IsFixedLength();
        });

        builder.Entity<LoanInterest>(entity =>
        {
            entity.Property(e => e.Interval).IsFixedLength();
            entity.Property(e => e.PaymentScheme).IsFixedLength();
        });

        builder.Entity<RepeatTransaction>(entity =>
        {
            entity.Property(e => e.IntervalDescription).IsFixedLength();
        });

        builder.Entity<TransactionType>(entity =>
        {
            entity.Property(e => e.Name).IsFixedLength();
        });

        builder.Entity<UserSetting>(entity =>
        {
            entity.Property(e => e.WeeklyStartDay).IsFixedLength();
        });

        OnModelCreatingPartial(builder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}