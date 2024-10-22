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

namespace MyMonie.Core.Models.App;

[Table("Currencies", Schema = "dbo")]
public partial class Currency
{
    public Currency()
    {
        UserSettingPrimaryCurrencies = [];
        UserSettingSecondaryCurrencies = [];
    }

    [Key]
    public byte Id { get; set; }
    [StringLength(5)]
    public string CountryCode { get; set; }
    [StringLength(5)]
    public string Symbol { get; set; }

    [InverseProperty(nameof(UserSetting.PrimaryCurrency))]
    public virtual ICollection<UserSetting> UserSettingPrimaryCurrencies { get; set; }
    [InverseProperty(nameof(UserSetting.SecondaryCurrency))]
    public virtual ICollection<UserSetting> UserSettingSecondaryCurrencies { get; set; }
}
