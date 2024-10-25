// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.EntityFrameworkCore;
using MyMonie.Models.App.Converters;
using MyMonie.Models.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyMonie.Models.App;

public partial class Code
{
    public int Id { get; set; }
    public required int UserId { get; set; }

    /// <summary>
    /// A 6 digit code to use for validation.
    /// </summary>
    [StringLength(6)]
    [Unicode(false)]
    public required string CodeText { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    [ValueConverter(typeof(CodeTypeConverter))]
    public required CodeType Type { get; set; }

    public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
    public required DateTime ExpiresOnUtc { get; set; }
    public bool IsUsed { get; set; }

    public virtual User User { get; set; }
}
