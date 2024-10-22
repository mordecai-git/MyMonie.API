// ========================================================================
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

[Table("Codes", Schema = "dbo")]
public partial class Code
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    [Column("Code")]
    [StringLength(6)]
    [Unicode(false)]
    public string Code1 { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsUsed { get; set; }

    [ForeignKey(nameof(UserId))]
    [InverseProperty("Codes")]
    public virtual User User { get; set; }
}
