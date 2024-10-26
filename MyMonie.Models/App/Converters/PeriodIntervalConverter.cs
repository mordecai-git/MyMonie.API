// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMonie.Models.Constants;
using System;

namespace MyMonie.Models.App.Converters;

internal class PeriodIntervalConverter : ValueConverter<PeriodInterval, string>
{
    public PeriodIntervalConverter() : base(
        v => v == PeriodInterval.BiAnnually
            ? "Bi-Annually" : v.ToString(),
        v => v == "Bi-Annually"
            ? PeriodInterval.BiAnnually : Enum.Parse<PeriodInterval>(v))
    { }
}
