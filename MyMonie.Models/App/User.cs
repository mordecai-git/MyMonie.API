// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.EntityFrameworkCore;
using MyMonie.Core.Models.App;
using MyMonie.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMonie.Models.App;

[Table(nameof(User), Schema = Schemas.Users)]
[Index(nameof(Email), IsUnique = true)]
public partial class User
{
    public int Id { get; set; }
    public Guid Uid { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Email { get; set; }

    public bool EmailVerified { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string PasswordHash { get; set; }
    public DateTime DateCreatedUtc { get; set; }
    public DateTime LastDateUpdatedUtc { get; set; }
    public byte ChannelId { get; set; }
    public bool? TwoFactorEnabled { get; set; }
    public int? AvatarId { get; set; }

    public virtual Document Avatar { get; set; }
    public virtual Channel Channel { get; set; }
    public virtual DarkMode DarkMode { get; set; }
    public virtual UserSetting UserSetting { get; set; }
    public virtual ICollection<AccountGroup> AccountGroups { get; set; }
    public virtual ICollection<Budget> Budgets { get; set; }
    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<Code> Codes { get; set; }
    public virtual ICollection<Loan> Loans { get; set; }
    public virtual ICollection<RepeatTransaction> RepeatTransactions { get; set; }
    public virtual ICollection<Transaction> Transactions { get; set; }
    public virtual ICollection<UserCategory> UserCategories { get; set; }
}