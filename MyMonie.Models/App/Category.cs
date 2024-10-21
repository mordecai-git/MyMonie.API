using Microsoft.EntityFrameworkCore;
using MyMonie.Core.Models.App;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMonie.Models.App;

[Table("Categories", Schema = "dbo")]
public partial class Category
{
    public Category()
    {
        Budgets = [];
        RepeatTransactions = [];
        Transactions = [];
        UserCategoryCategories = [];
        UserCategoryParents = [];
    }

    [Key]
    public int Id { get; set; }
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;
    public DateTime DateCreated { get; set; }
    public int CreatedById { get; set; }

    [ForeignKey(nameof(CreatedById))]
    [InverseProperty(nameof(User.Categories))]
    public virtual User CreatedBy { get; set; } = null!;
    [InverseProperty(nameof(Budget.Category))]
    public virtual ICollection<Budget> Budgets { get; set; }
    [InverseProperty(nameof(RepeatTransaction.Category))]
    public virtual ICollection<RepeatTransaction> RepeatTransactions { get; set; }
    [InverseProperty(nameof(Transaction.Category))]
    public virtual ICollection<Transaction> Transactions { get; set; }
    [InverseProperty(nameof(UserCategory.Category))]
    public virtual ICollection<UserCategory> UserCategoryCategories { get; set; }
    [InverseProperty(nameof(UserCategory.Parent))]
    public virtual ICollection<UserCategory> UserCategoryParents { get; set; }
}
