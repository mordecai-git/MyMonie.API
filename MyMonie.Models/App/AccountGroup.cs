// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MyMonie.Models.App;

namespace MyMonie.Core.Models.App;

[Table("AccountGroups", Schema = "dbo")]
public partial class AccountGroup
{
    public AccountGroup()
    {
        Accounts = [];
    }

    [Key]
    public int Id { get; set; }
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; }
    [StringLength(10)]
    [Unicode(false)]
    public string Type { get; set; }
    public int UserId { get; set; }
    public bool IsPermanent { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DateDeleted { get; set; }

    [ForeignKey(nameof(UserId))]
    [InverseProperty("AccountGroups")]
    public virtual User User { get; set; }
    [InverseProperty(nameof(Account.AccountGroup))]
    public virtual ICollection<Account> Accounts { get; set; }
}
