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
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMonie.Models.App;

[Table("Budgets", Schema = Schemas.Account)]
[Index(nameof(UserId), nameof(Period), nameof(CategoryId), IsUnique = true)]
public partial class Budget : BaseAppModel
{
    public required int UserId { get; set; }

    /// <summary>
    /// Users can set budget for individual categories, when null it means the budget is for all category.
    /// </summary>
    public int? CategoryId { get; set; }

    [Column(TypeName = "money")]
    public required decimal Amount { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    [ValueConverter(typeof(PeriodIntervalConverter))]
    public required PeriodInterval Period { get; set; }

    public virtual Category Category { get; set; }
    public virtual User User { get; set; }
}