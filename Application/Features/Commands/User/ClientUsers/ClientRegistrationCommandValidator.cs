using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.ClientUsers;

public class ClientRegistrationCommandValidator : AbstractValidator<ClientRegistrationCommand>
{
    public ClientRegistrationCommandValidator()
    {
        RuleFor(p => p.FirstName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(p => p.LastName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(p => p.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .EmailAddress()
            .WithMessage("A valid email is required.")
            .NotNull();

        RuleFor(p => p.PhoneNumber)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(12)
            .WithMessage("{PropertyName} must not be less than 10 digits.")
            .MaximumLength(12)
            .WithMessage("{PropertyName} must not be exceed 10 digits.")
            .Matches(@"^\d{3}-\d{3}-\d{4}$")
            .WithMessage("{PropertyName} is not valid. Expected format: 123-456-7890.");

        RuleFor(p => p.Gender)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(p => p.DateOfBirth)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull();
    }
}
