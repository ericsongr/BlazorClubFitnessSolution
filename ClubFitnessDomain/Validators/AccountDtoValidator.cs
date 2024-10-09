using FluentValidation;
using ClubFitnessDomain.Dtos;

namespace ClubFitnessDomain.Validators
{
    public class AccountDtoValidator : AbstractValidator<Account>
    {
        public AccountDtoValidator()
        {
            RuleFor(account => account.AccountName)
                .NotEmpty().WithMessage("Account Name is required.");

            RuleFor(account => account.Timezone)
                .NotEmpty().WithMessage("Timezone is required.");
        }
    }
}