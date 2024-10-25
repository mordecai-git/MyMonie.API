// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using MyMonie.Models.Constants;
using MyMonie.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMonie.Models.App;

[Table("LoanRepayments", Schema = Schemas.Loans)]
public partial class LoanRepayment : BaseAppModel, ISoftDeletable
{
    public required int LoanId { get; set; }
    public required int AccountId { get; set; }
    [Column(TypeName = "money")]
    public required decimal Amount { get; set; }

    public bool IsDeleted { get; set; }
    public int? DeletedById { get; set; }
    public DateTime? DeletedOnUtc { get; set; }

    public virtual Account Account { get; set; }
    public virtual Loan Loan { get; set; }
}
