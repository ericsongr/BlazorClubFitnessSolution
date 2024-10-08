using ClubFitnessDomain.Dtos;
using FluentValidation;

namespace ClubFitnessDomain.Validators
{
    public class AccountProductCategoryDtoValidator : AbstractValidator<AccountProductCategoryDto>
    {
        public AccountProductCategoryDtoValidator()
        {
            RuleFor(x => x.AccountId)
                .NotEmpty().WithMessage("Please select account.");

            RuleFor(x => x.ProductCategoryName)
                .NotEmpty().WithMessage("Product Category Name is required.");
        }
    }
}