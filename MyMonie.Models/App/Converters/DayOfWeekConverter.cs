// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace MyMonie.Models.App.Converters;
public class DayOfWeekConverter : ValueConverter<DayOfWeek, string>
{
    public DayOfWeekConverter() : base(
        v => v.ToString(),
        v => Enum.Parse<DayOfWeek>(v))
    { }
}