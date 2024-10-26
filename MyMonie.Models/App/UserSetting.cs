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

[Table("UserSettings", Schema = Schemas.Users)]
public partial class UserSetting
{
    [Key]
    public required int UserId { get; set; }
    public required byte PrimaryCurrencyId { get; set; }
    public required byte SecondaryCurrencyId { get; set; }
    public byte MonthlyStartDay { get; set; } = 1;

    [StringLength(10)]
    [Unicode(false)]
    [ValueConverter(typeof(DayOfWeekConverter))]
    public DayOfWeek WeeklyStartDay { get; set; } = DayOfWeek.Monday;

    public bool IsCarryOver { get; set; }
    public bool ShowDescription { get; set; } = true;

    [StringLength(255)]
    [Unicode(false)]
    public string PasscodeHash { get; set; } // TODO: Encripty this

    public DateTime? MobileReminderTime { get; set; }
    public DateTime? EmailReminderTime { get; set; }

    public virtual Currency PrimaryCurrency { get; set; }
    public virtual Currency SecondaryCurrency { get; set; }
    public virtual User User { get; set; }
}
