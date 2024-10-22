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
    public int UserId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string HashedToken { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ExpiryDateUtc { get; set; }

    [Column(TypeName = "datetime")]
    public new DateTime? DateCreatedUtc { get; set; }

    public virtual User User { get; set; }
}
