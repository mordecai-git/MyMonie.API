// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using System;

namespace MyMonie.Models.CacheKeys;
public partial class CacheKeys
{
    public static string ValidateToken(Guid uid) => $"ValidateToken-{uid}";
}
