// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using System;

namespace MyMonie.Models.Interfaces;
public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
    int? DeletedById { get; set; }
    DateTime? DeletedOnUtc { get; set; }
}
