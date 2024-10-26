// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.EntityFrameworkCore;
using MyMonie.Models.App.Converters;
using MyMonie.Models.Constants;
using MyMonie.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMonie.Models.App;

[Table("AccountGroups", Schema = Schemas.Account)]
public partial class AccountGroup : BaseAppModel, ISoftDeletable
{
    [StringLength(255)]
    [Unicode(false)]
    public required string Name { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    [ValueConverter(typeof(AccountGroupTypeConverter))]
    public required AccountGroupType Type { get; set; } = AccountGroupType.Account;
    public required int UserId { get; set; }

    /// <summary>
    /// This determines if this account group is deletable or not.
    /// </summary>
    public bool IsPermanent { get; set; }
    public bool IsDeleted { get; set; }
    public int? DeletedById { get; set; }
    public DateTime? DeletedOnUtc { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<Account> Accounts { get; set; }
}