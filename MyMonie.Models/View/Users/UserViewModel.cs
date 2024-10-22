// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using System;

namespace MyMonie.Models.View.Users;
public class UserViewModel
{
    public int Id { get; set; }
    public Guid Uid { get; set; }
    public string Email { get; set; }
    public bool EmailVerified { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AvatarUrl { get; set; }
}