// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMonie.Models.Constants;
using System;

namespace MyMonie.Models.App.Converters;

internal class LoanTypeConverter : ValueConverter<LoanTypes, string>
{
    public LoanTypeConverter() : base(
        v => v == LoanTypes.Inbound
            ? "Inbound" : v.ToString(),
        v => v == "Inbound"
            ? LoanTypes.Inbound : Enum.Parse<LoanTypes>(v))
    { }
}
