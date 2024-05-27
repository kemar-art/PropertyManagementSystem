using Domain.Repository_Interface;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Features.Commands.UpdateForm
{
    public class UpdateFormCommandValidator : AbstractValidator<UpdateFormCommand>
    {
        private readonly IFormRepository _formRepository;

        public UpdateFormCommandValidator(IFormRepository formRepository)
        {
            _formRepository = formRepository;

            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(FormIdMustExist);

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
                .MaximumLength(10)
                .WithMessage("{PropertyName} must not be less than 10 digits.")
                .MaximumLength(10)
                .WithMessage("{PropertyName} must not be exceed 10 digits.")
                .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"))
                .WithMessage("{PropertyName} not valid");

            RuleFor(p => p.InstructionsIssuedBy)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.PropertyDirection)
               .NotEmpty()
               .WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.Volume)
               .NotEmpty()
               .WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.Folio)
               .NotEmpty()
               .WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.StrataPlan)
              .NotEmpty()
              .WithMessage("{PropertyName} is required.")
              .NotNull();

            RuleFor(p => p.IsKeyAvailable)
              .NotEmpty()
              .WithMessage("{PropertyName} is required.")
              .NotNull();

            RuleFor(p => p.MortgageInstitution)

              .NotEmpty()
              .WithMessage("{PropertyName} is required.")
              .NotNull();

            RuleFor(p => p.SecondaryContactFirstName)
             .NotEmpty()
             .WithMessage("{PropertyName} is required.")
             .NotNull();

            RuleFor(p => p.SecondaryContactLastName)
             .NotEmpty()
             .WithMessage("{PropertyName} is required.")
             .NotNull();

            RuleFor(p => p.SecondaryContactEmail)
             .NotEmpty()
             .WithMessage("{PropertyName} is required.")
             .EmailAddress()
             .WithMessage("A valid email is required.")
             .NotNull();

            RuleFor(p => p.SecondaryContactPhoneNumber)
             .NotEmpty()
             .WithMessage("{PropertyName} is required.")
             .NotNull()
             .MaximumLength(10)
             .WithMessage("Phone number must not be less than 10 digits.")
             .MaximumLength(10)
             .WithMessage("{PropertyName} must not be exceed 10 digits.")
             .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"))
             .WithMessage("Phone number not valid");
        }

        private async Task<bool> FormIdMustExist(int id, CancellationToken token)
        {
            var checkIfFormIdExist = await _formRepository.GetByIdAsync(id);
            return checkIfFormIdExist != null;
        }
    }
}
