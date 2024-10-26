// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMonie.Models.App;
public partial class Login : BaseAppModel
{
    public required int UserId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public required string HashedToken { get; set; }

    [Column(TypeName = "datetime2(7)")]
    public required DateTime ExpiryDateUtc { get; set; }

    [Column(TypeName = "datetime2(7)")]
    public DateTime? UpdatedOnUtc { get; set; }

    public virtual User User { get; set; }
}
