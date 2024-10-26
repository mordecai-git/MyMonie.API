// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.EntityFrameworkCore;
using MyMonie.Models.Constants;
using MyMonie.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMonie.Models.App;

/// <summary>
/// This table stores the group information of users
/// </summary>
[Table("Groups", Schema = Schemas.Account)]
public partial class Group : BaseAppModel, ISoftDeletable
{
    [StringLength(255)]
    [Unicode(false)]
    public required string Name { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string Description { get; set; }

    public bool IsDeleted { get; set; }
    public int? DeletedById { get; set; }
    public DateTime? DeletedOnUtc { get; set; }
}
