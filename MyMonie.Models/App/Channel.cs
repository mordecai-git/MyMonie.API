// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMonie.Models.App;

public partial class Channel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public byte Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; }

    public virtual ICollection<Loan> Loans { get; set; }
    public virtual ICollection<RepeatTransaction> RepeatTransactions { get; set; }
    public virtual ICollection<Transaction> Transactions { get; set; }
    public virtual ICollection<User> Users { get; set; }
}
