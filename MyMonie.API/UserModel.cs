// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

using FluentValidation;

namespace MyMonie.API;

public class UserModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public class UserModelValidator : AbstractValidator<UserModel>
{
    public UserModelValidator() {
        RuleFor(item => item.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(item => item.Description)
            .NotEmpty()
            .WithMessage("Description is required.");
    }
}
