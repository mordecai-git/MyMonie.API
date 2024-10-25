// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMonie.Models.Constants;
using System;

namespace MyMonie.Models.App.Converters;
internal class AccountGroupTypeConverter : ValueConverter<AccountGroupType, string>
{
    public AccountGroupTypeConverter() : base(
        v => v.ToString(),
        v => Enum.Parse<AccountGroupType>(v))
    { }
}
