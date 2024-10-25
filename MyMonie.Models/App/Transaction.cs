// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using MyMonie.Models.Constants;
using MyMonie.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMonie.Models.App;

[Table("Transactions", Schema = Schemas.Transactions)]
public partial class Transaction : BaseAppModel, ISoftDeletable
{
    public required int UserId { get; set; }
    [Column(TypeName = "money")]
    public required decimal Amount { get; set; }
    public required int CategoryId { get; set; }
    public required short TransactionTypeId { get; set; }
    public required byte ChannelId { get; set; }
    public int? DeletedById { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOnUtc { get; set; }

    public virtual Category Category { get; set; }
    public virtual Channel Channel { get; set; }
    public virtual TransactionType TransactionType { get; set; }
    public virtual User User { get; set; }
}
