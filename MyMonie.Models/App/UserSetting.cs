// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MyMonie.Models.App;

namespace MyMonie.Core.Models.App;

[Table("UserSettings", Schema = "dbo")]
public partial class UserSetting
{
    [Key]
    public int UserId { get; set; }
    public byte PrimaryCurrencyId { get; set; }
    public byte SecondaryCurrencyId { get; set; }
    public byte? MonthlyStartDate { get; set; }
    [StringLength(10)]
    [Unicode(false)]
    public string WeeklyStartDay { get; set; }
    public bool IsCarryOver { get; set; }
    public bool ShowDescription { get; set; }
    public bool AutoCompleteActive { get; set; }
    public short? Passcode { get; set; }
    public DateTime? MobileReminderTime { get; set; }
    public DateTime? EmailReminderTime { get; set; }

    [ForeignKey(nameof(PrimaryCurrencyId))]
    [InverseProperty(nameof(Currency.UserSettingPrimaryCurrencies))]
    public virtual Currency PrimaryCurrency { get; set; }
    [ForeignKey(nameof(SecondaryCurrencyId))]
    [InverseProperty(nameof(Currency.UserSettingSecondaryCurrencies))]
    public virtual Currency SecondaryCurrency { get; set; }
    [ForeignKey(nameof(UserId))]
    [InverseProperty("UserSetting")]
    public virtual User User { get; set; }
}
