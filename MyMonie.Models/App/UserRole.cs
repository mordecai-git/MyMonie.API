// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyMonie.Models.App;

[PrimaryKey(nameof(UserId), nameof(RoleId))]
public class UserRole
{
    /// <summary>
    /// A foreign key to the user this role is attached to
    /// </summary>
    [Required]
    public required int UserId { get; set; }

    /// <summary>
    /// A foreign key to the role this user possess
    /// </summary>
    [Required]
    public required int RoleId { get; set; }

    /// <summary>
    /// A foreign key to the user who assigned this role to this user
    /// </summary>
    [Required]
    public required int CreatedById { get; set; }
    public Role Role { get; set; }
    public User User { get; set; }
}