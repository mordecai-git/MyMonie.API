
// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMonie.Models.Constants;

namespace MyMonie.Models.App.Converters;

internal class LoanRepaymentStatusConverter : ValueConverter<LoanRepaymentStatus, string>
{
    public LoanRepaymentStatusConverter() : base(
        v => v == LoanRepaymentStatus.NoPayment
            ? "No Payment"
            : v == LoanRepaymentStatus.PartialPayment
                ? "Partial Payment" : "Full Payment",
        v => v == "Inbound"
            ? LoanRepaymentStatus.NoPayment
            : v == "Partial Payment"
                ? LoanRepaymentStatus.PartialPayment : LoanRepaymentStatus.FullPayment)
    { }
}
