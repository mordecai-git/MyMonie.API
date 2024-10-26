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
    public required int UserId { get; set; }
    [Required]
    [MaxLength(255)]
    public required string Code { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime ExpiresOnUtc { get; set; }
    public DateTime UpdatedOnUtc { get; set; }
    public User User { get; set; }
}