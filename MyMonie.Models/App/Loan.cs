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

[Table("Loans", Schema = Schemas.Loans)]
public partial class Loan : BaseAppModel, ISoftDeletable
{
    public required int UserId { get; set; }
    public required int AccountId { get; set; }
    public int? InterestId { get; set; }

    /// <summary>
    /// Inbound: The money the user borrowed; Outbound: The money that the user borrowed others
    /// </summary>
    [StringLength(4)]
    [Unicode(false)]
    [ValueConverter(typeof(LoanTypeConverter))]
    public required LoanTypes LoanType { get; set; }

    /// <summary>
    /// The name of person or entity the user is taking or giving a loan
    /// </summary>
    [StringLength(255)]
    [Unicode(false)]
    public required string Name { get; set; }

    /// <summary>
    /// The amount borrowed or borrowed out. This is the principal amount
    /// </summary>
    [Column(TypeName = "money")]
    public required decimal Amount { get; set; }

    /// <summary>
    /// The amount remaining. 
    /// </summary>
    [Column(TypeName = "money")]
    public required decimal Balance { get; set; }

    [Column(TypeName = "money")]
    public required decimal RepaymentAmountPerPeriod { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    [ValueConverter(typeof(PeriodIntervalConverter))]
    public required PeriodInterval RepaymentInterval { get; set; }

    /// <summary>
    /// When null, no payment made yet; when false/0, partial payment made; when true/1, full payment made
    /// </summary>
    [ValueConverter(typeof(LoanRepaymentStatusConverter))]
    public required LoanRepaymentStatus RepaymentStatus { get; set; }

    public DateTime? FullRepaymentDateUtc { get; set; }
    public required DateTime DeadlineDateUtc { get; set; }
    public required byte ChannelId { get; set; }
    public bool IsDeleted { get; set; }
    public int? DeletedById { get; set; }
    public DateTime? DeletedOnUtc { get; set; }

    public virtual Account Account { get; set; }
    public virtual Channel Channel { get; set; }
    public virtual LoanInterest Interest { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<LoanInterest> LoanInterests { get; set; }
    public virtual ICollection<LoanRepayment> LoanRepayments { get; set; }
}
