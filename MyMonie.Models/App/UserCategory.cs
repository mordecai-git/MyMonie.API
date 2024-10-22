// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using MyMonie.Models.App;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMonie.Core.Models.App;

[Table("UserCategories", Schema = "dbo")]
public partial class UserCategory
{
    [Key]
    public int CategoryId { get; set; }
    [Key]
    public int UserId { get; set; }
    public short TransactionTypeId { get; set; }
    public int? ParentId { get; set; }
    public bool IsDeleted { get; set; }

    [ForeignKey(nameof(CategoryId))]
    [InverseProperty("UserCategoryCategories")]
    public virtual Category Category { get; set; }
    [ForeignKey(nameof(ParentId))]
    [InverseProperty("UserCategoryParents")]
    public virtual Category Parent { get; set; }
    [ForeignKey(nameof(TransactionTypeId))]
    [InverseProperty("UserCategories")]
    public virtual TransactionType TransactionType { get; set; }
    [ForeignKey(nameof(UserId))]
    [InverseProperty("UserCategories")]
    public virtual User User { get; set; }
}
