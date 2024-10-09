using FluentValidation;
using ClubFitnessDomain.Dtos;

namespace ClubFitnessDomain.Validators
{
    public class AccountProductSubCategoryDtoValidator : AbstractValidator<Dtos.AccountProductSubCategoryDto>
    {
        public AccountProductSubCategoryDtoValidator()
        {
            RuleFor(x => x.AccountId)
                .NotEmpty().WithMessage("Please select account.");

            RuleFor(x => x.AccountProductCategoryId)
                .NotEmpty().WithMessage("Please select product category.");

            RuleFor(x => x.ProductSubCategoryName)
                .NotEmpty().WithMessage("Product Sub-Category Name is required.")
                .MaximumLength(40).WithMessage("Product Sub-Category Name must be at most 40 characters.");
        }
    }
}