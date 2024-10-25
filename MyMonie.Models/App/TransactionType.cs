// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.EntityFrameworkCore;
using MyMonie.Models.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMonie.Models.App;

[Table("TransactionTypes", Schema = Schemas.Transactions)]
public partial class TransactionType
{
    [Key]
    public short Id { get; set; }

    /// <summary>
    /// Expense, Income, Transfer, Loan
    /// </summary>
    [StringLength(8)]
    [Unicode(false)]
    public string Name { get; set; }

    public virtual ICollection<RepeatTransaction> RepeatTransactions { get; set; }
    public virtual ICollection<Transaction> Transactions { get; set; }
}
