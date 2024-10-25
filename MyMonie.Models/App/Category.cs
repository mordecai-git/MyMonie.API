// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.EntityFrameworkCore;
using MyMonie.Models.Constants;
using MyMonie.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMonie.Models.App;

[Table("Categories", Schema = Schemas.Account)]
public partial class Category : BaseAppModel, ISoftDeletable
{
    [StringLength(255)]
    [Unicode(false)]
    public required string Name { get; set; }

    /// <summary>
    /// Stores the name in lower case and space character replaced with hypen
    /// </summary>
    [StringLength(100)]
    [Unicode(false)]
    public required string Tag { get; set; }
    public bool IsDeleted { get; set; }
    public int? DeletedById { get; set; }
    public DateTime? DeletedOnUtc { get; set; }

    public virtual ICollection<Budget> Budgets { get; set; }
    public virtual ICollection<RepeatTransaction> RepeatTransactions { get; set; }
    public virtual ICollection<Transaction> Transactions { get; set; }
}
