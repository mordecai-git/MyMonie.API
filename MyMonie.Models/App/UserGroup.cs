﻿// ========================================================================
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

[Keyless]
[Table("UserGroups", Schema = "dbo")]
public partial class UserGroup
{
    public int UserId { get; set; }
    public int GroupId { get; set; }
    public bool IsOwner { get; set; }

    [ForeignKey(nameof(GroupId))]
    public virtual Group Group { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }
}
