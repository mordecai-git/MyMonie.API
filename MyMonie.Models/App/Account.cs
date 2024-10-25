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

[Table("Accounts", Schema = Schemas.Account)]
public partial class Account : BaseAppModel, ISoftDeletable
{
    public required int UserId { get; set; }

    public required int AccountGroupId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public required string Name { get; set; }

    [Column(TypeName = "money")]
    public decimal Balance { get; set; } = 0m;

    /// <summary>
    /// Record outgoing transfers as expense and incoming tranfers
    /// as income. E.g., for savings, investments, etc
    /// </summary>
    public bool RecordTransferAsExpense { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string Description { get; set; }

    /// <summary>
    /// This is only required when account belogs to a group that is
    /// either a CreditCard or DebitCard group.
    /// </summary>
    public int? BillingAccountId { get; set; }

    /// <summary>
    /// This is only required when account belogs to a group that is
    /// either a CreditCard or DebitCard group.
    /// This is the date that the cycle ends and the bill is generated
    /// </summary>
    public DateTime? SettlementDateUtc { get; set; }

    /// <summary>
    /// This is only required when account belogs to a group that is
    /// either a CreditCard or DebitCard group.
    /// This is the date that the bill is due for payment.
    /// </summary>
    public DateTime? PaymentDateUtc { get; set; }

    public bool IsDeleted { get; set; }
    public int? DeletedById { get; set; }
    public DateTime? DeletedOnUtc { get; set; }

    public virtual User User { get; set; }
    public virtual AccountGroup AccountGroup { get; set; }
    public virtual Account BillingAccount { get; set; }
    public virtual ICollection<LoanRepayment> LoanRepayments { get; set; }
    public virtual ICollection<Loan> Loans { get; set; }
}
