// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using System;
using System.ComponentModel.DataAnnotations;

namespace MyMonie.Models.App;
public class RefreshToken
{
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    [MaxLength(255)]
    public string Code { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime ExpiresAtUtc { get; set; }
    public DateTime UpdatedAtUtc { get; set; }
    public User User { get; set; }
}