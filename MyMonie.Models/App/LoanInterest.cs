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

[Table("LoanInterests", Schema = Schemas.Loans)]
public partial class LoanInterest : BaseAppModel, ISoftDeletable
{
    public required int LoanId { get; set; }
    public required short Percentage { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    [ValueConverter(typeof(PeriodIntervalConverter))]
    public required PeriodInterval Interval { get; set; }

    [StringLength(13)]
    [Unicode(false)]
    [ValueConverter(typeof(LoanInterestPaymentConverter))]
    public required LoanInterestPaymentScheme PaymentScheme { get; set; }

    public bool IsDeleted { get; set; }
    public int? DeletedById { get; set; }
    public DateTime? DeletedOnUtc { get; set; }

    public virtual Loan Loan { get; set; }
    public virtual ICollection<Loan> Loans { get; set; }
}
