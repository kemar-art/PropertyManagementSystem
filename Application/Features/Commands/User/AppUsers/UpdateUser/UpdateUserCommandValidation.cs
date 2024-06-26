using Application.Contracts.Repository_Interface;
using Domain.Repository_Interface;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.AppUsers.UpdateUser
{
    public class UpdateUserCommandValidation : AbstractValidator<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandValidation(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(UserIdMustExist)
                .WithMessage("The specified condition was not met for {PropertyName} with value {PropertyValue}.");

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

            RuleFor(p => p.Address)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
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

            RuleFor(p => p.TaxRegistrationNumber)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.NationalInsuranceScheme)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull();


            RuleFor(p => p.Gender)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.DateOfBirth)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull();
        }

        private async Task<bool> UserIdMustExist(string id, CancellationToken token)
        {
            var checkIfUserIdExist = await _userRepository.GetByIdAsync(id);
            return checkIfUserIdExist != null;
        }
    }
}
