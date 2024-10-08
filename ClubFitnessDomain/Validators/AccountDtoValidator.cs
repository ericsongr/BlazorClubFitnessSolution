using FluentValidation;
using ClubFitnessDomain.Dtos;

namespace ClubFitnessDomain.Validators
{
    public class AccountDtoValidator : AbstractValidator<AccountDto>
    {
        public AccountDtoValidator()
        {
            RuleFor(account => account.AccountName)
                .NotEmpty().WithMessage("Account Name is required.")
                .NotNull().WithMessage("Account Name cannot be null.");

            RuleFor(account => account.Timezone)
                .NotEmpty().WithMessage("Timezone is required.")
                .NotNull().WithMessage("Timezone cannot be null.");
        }
    }
}