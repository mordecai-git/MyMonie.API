// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.EntityFrameworkCore;
using MyMonie.Models.Constants;
using MyMonie.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMonie.Models.App;

[Keyless]
[Table("UserGroups", Schema = Schemas.Users)]
public partial class UserGroup : ISoftDeletable
{
    public required int UserId { get; set; }
    public required int GroupId { get; set; }

    /// <summary>
    /// Stores if this user is the owner/administrator of this group
    /// </summary>
    public bool IsOwner { get; set; } = false;

    /// <summary>
    /// Stores if this user has admin rights for this user group
    /// </summary>
    public bool IsAdmin { get; set; } = false;

    public required int AddedById { get; set; }
    public DateTime AddedOnUtc { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; }
    public int? DeletedById { get; set; }
    public DateTime? DeletedOnUtc { get; set; }

    public virtual Group Group { get; set; }
    public virtual User User { get; set; }
}
