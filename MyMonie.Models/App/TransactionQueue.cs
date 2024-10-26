// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using MyMonie.Models.Constants;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMonie.Models.App;

/// <summary>
/// This table is checked daily for repeat transactions to be executed that day.
/// After it's executed, it gets the next execution based on the interval from RepeatTransaction table
/// </summary>
[Table("TransactionQueues", Schema = Schemas.Transactions)]
public partial class TransactionQueue
{
    public int Id { get; set; }
    public required int RepeatTransactionId { get; set; }
    public required DateTime NextExecutionDateUtc { get; set; }
    public bool IsDone { get; set; }

    public virtual RepeatTransaction RepeatTransaction { get; set; }
}
