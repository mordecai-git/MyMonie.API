﻿// ========================================================================
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

[Table("Channels", Schema = "dbo")]
public partial class Channel
{
    public Channel()
    {
        DarkModes = [];
        Loans = [];
        RepeatTransactions = [];
        Transactions = [];
        Users = [];
    }

    [Key]
    public byte Id { get; set; }
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; }

    [InverseProperty(nameof(DarkMode.Channel))]
    public virtual ICollection<DarkMode> DarkModes { get; set; }
    [InverseProperty(nameof(Loan.Channel))]
    public virtual ICollection<Loan> Loans { get; set; }
    [InverseProperty(nameof(RepeatTransaction.Channel))]
    public virtual ICollection<RepeatTransaction> RepeatTransactions { get; set; }
    [InverseProperty(nameof(Transaction.Channel))]
    public virtual ICollection<Transaction> Transactions { get; set; }
    [InverseProperty(nameof(User.Channel))]
    public virtual ICollection<User> Users { get; set; }
}
