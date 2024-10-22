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

namespace MyMonie.Core.Models.App;

[Table("Groups", Schema = "dbo")]
public partial class Group
{
    [Key]
    public int Id { get; set; }
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; }
    [StringLength(2000)]
    [Unicode(false)]
    public string Description { get; set; }
}
