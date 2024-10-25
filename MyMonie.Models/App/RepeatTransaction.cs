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

/// <summary>
/// This table stores the details of every repeating transations
/// </summary>
[Table("RepeatTransactions", Schema = Schemas.Transactions)]
public partial class RepeatTransaction : BaseAppModel, ISoftDeletable
{
    public required int UserId { get; set; }
    [Column(TypeName = "money")]
    public required decimal Amount { get; set; }
    public required int CategoryId { get; set; }
    public required short TransactionTypeId { get; set; }
    public required short IntervalCount { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    [ValueConverter(typeof(PeriodIntervalConverter))]
    public required PeriodInterval IntervalDescription { get; set; }

    public required DateTime? EndDate { get; set; }
    public required byte ChannelId { get; set; }
    public int? DeletedById { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOnUtc { get; set; }

    public virtual Category Category { get; set; }
    public virtual Channel Channel { get; set; }
    public virtual TransactionType TransactionType { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<TransactionQueue> TransactionQueues { get; set; }
}
