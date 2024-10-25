// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyMonie.Models.App;

public partial class Currency
{
    [Key]
    public byte Id { get; set; }
    [StringLength(5)]
    public string CountryCode { get; set; }
    [StringLength(5)]
    public string Symbol { get; set; }

    public virtual ICollection<UserSetting> UserSettingPrimaryCurrencies { get; set; }
    public virtual ICollection<UserSetting> UserSettingSecondaryCurrencies { get; set; }
}
