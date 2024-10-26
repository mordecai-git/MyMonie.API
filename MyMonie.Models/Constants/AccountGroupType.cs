// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

namespace MyMonie.Models.Constants;
public enum AccountGroupType
{
    /// <summary>
    /// Default type
    /// </summary>
    Account,

    /// <summary>
    /// This type is used for debit cards and must be tied to another account as the billing account
    /// </summary>
    DebitCard,

    /// <summary>
    /// This type is used for credit cards and must be tied to another account as the billing account
    /// </summary>
    CreditCard
}
