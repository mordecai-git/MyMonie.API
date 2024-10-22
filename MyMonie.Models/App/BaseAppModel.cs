// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using System;

namespace MyMonie.Models.App;
public class BaseAppModel
{
    public int Id { get; set; }
    public Guid Uid { get; set; }
    public int CreatedById { get; set; }
    public DateTime DateCreatedUtc { get; set; } = DateTime.UtcNow;
    public int? UpdatedById { get; set; }
    public DateTime? DateUpdatedUtc { get; set; }
    public User CreatedBy { get; set; }
    public User UpdatedBy { get; set; }
}
