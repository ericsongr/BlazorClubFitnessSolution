using FluentValidation;
using ClubFitnessDomain.Dtos;

namespace ClubFitnessDomain.Validators
{
    public class AccountSupplierValidator : AbstractValidator<AccountSupplier>
    {
        public AccountSupplierValidator()
        {
            RuleFor(account => account.AccountId)
                .NotEmpty().WithMessage("Please select account.");

            RuleFor(account => account.SupplierName)
                .NotEmpty().WithMessage("Supplier name is required.");

            RuleFor(account => account.ContactFirstName)
                .NotEmpty().WithMessage("First name is required.");

            RuleFor(account => account.ContactLastName)
                .NotEmpty().WithMessage("Last name is required.");

            RuleFor(account => account.ContactEmail)
                .NotEmpty().WithMessage("Email is required.");

            RuleFor(account => account.ContactMobile)
                .NotEmpty().WithMessage("Mobile number is required.");
        }
    }
}