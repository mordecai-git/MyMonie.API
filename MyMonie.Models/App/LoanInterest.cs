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

namespace MyMonie.Core.Models.App;

[Table("LoanInterests", Schema = "dbo")]
public partial class LoanInterest
{
    public LoanInterest()
    {
        Loans = [];
    }

    [Key]
    public int Id { get; set; }
    public int LoanId { get; set; }
    public short Percentage { get; set; }
    [StringLength(10)]
    [Unicode(false)]
    public string Interval { get; set; }
    [StringLength(13)]
    [Unicode(false)]
    public string PaymentScheme { get; set; }

    [ForeignKey(nameof(LoanId))]
    [InverseProperty("LoanInterests")]
    public virtual Loan Loan { get; set; }
    [InverseProperty("Interest")]
    public virtual ICollection<Loan> Loans { get; set; }
}
