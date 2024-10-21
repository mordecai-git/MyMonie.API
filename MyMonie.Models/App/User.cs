using Microsoft.EntityFrameworkCore;
using MyMonie.Core.Models.App;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMonie.Models.App;

[Table("Users", Schema = "dbo")]
[Index(nameof(Email), Name = "UQ__Users__A9D10534EC57A06E", IsUnique = true)]
public partial class User
{
    public User()
    {
        AccountGroups = [];
        Budgets = [];
        Categories = [];
        Codes = [];
        Loans = [];
        RepeatTransactions = [];
        Transactions = [];
        UserCategories = [];
    }

    [Key]
    public int Id { get; set; }
    [StringLength(150)]
    [Unicode(false)]
    public string Email { get; set; } = null!;
    public bool EmailVerified { get; set; }
    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;
    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;
    [StringLength(255)]
    [Unicode(false)]
    public string PasswordHash { get; set; } = null!;
    public DateTime DateCreated { get; set; }
    public byte ChannelId { get; set; }
    public bool? TwoFactorEnabled { get; set; }

    [ForeignKey(nameof(ChannelId))]
    [InverseProperty("Users")]
    public virtual Channel Channel { get; set; } = null!;
    [InverseProperty("User")]
    public virtual DarkMode DarkMode { get; set; } = null!;
    [InverseProperty("User")]
    public virtual UserSetting UserSetting { get; set; } = null!;
    [InverseProperty(nameof(AccountGroup.User))]
    public virtual ICollection<AccountGroup> AccountGroups { get; set; }
    [InverseProperty(nameof(Budget.User))]
    public virtual ICollection<Budget> Budgets { get; set; }
    [InverseProperty(nameof(Category.CreatedBy))]
    public virtual ICollection<Category> Categories { get; set; }
    [InverseProperty(nameof(Code.User))]
    public virtual ICollection<Code> Codes { get; set; }
    [InverseProperty(nameof(Loan.User))]
    public virtual ICollection<Loan> Loans { get; set; }
    [InverseProperty(nameof(RepeatTransaction.User))]
    public virtual ICollection<RepeatTransaction> RepeatTransactions { get; set; }
    [InverseProperty(nameof(Transaction.User))]
    public virtual ICollection<Transaction> Transactions { get; set; }
    [InverseProperty(nameof(UserCategory.User))]
    public virtual ICollection<UserCategory> UserCategories { get; set; }
}