using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyMonie.Core.Models.App;

[Table("TransactionTypes", Schema = "dbo")]
public partial class TransactionType
{
    public TransactionType()
    {
        RepeatTransactions = [];
        Transactions = [];
        UserCategories = [];
    }

    [Key]
    public short Id { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty(nameof(RepeatTransaction.TransactionType))]
    public virtual ICollection<RepeatTransaction> RepeatTransactions { get; set; }
    [InverseProperty(nameof(Transaction.TransactionType))]
    public virtual ICollection<Transaction> Transactions { get; set; }
    [InverseProperty(nameof(UserCategory.TransactionType))]
    public virtual ICollection<UserCategory> UserCategories { get; set; }
}
