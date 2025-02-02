﻿using FluentValidation;

namespace ClubFitnessDomain.Validators
{
    public class AccountProductValidator : AbstractValidator<AccountProduct>
    {
        public AccountProductValidator()
        {
            RuleFor(x => x.AccountId).NotEmpty().WithMessage("Please select account.");
            RuleFor(x => x.AccountSupplierId).NotEmpty().WithMessage("Please select supplier.");
            RuleFor(x => x.AccountProductCategoryId).NotEmpty().WithMessage("Please select product category.");
            RuleFor(x => x.AccountProductSubCategoryId).NotEmpty().WithMessage("please select product sub-category");
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Product Name is required.");

            RuleFor(x => x.SellExTaxPrice).NotEmpty().WithMessage("Sell Excluded Tax Price is required.");
            RuleFor(x => x.SellIncTaxPrice).NotEmpty().WithMessage("Sell Included Tax Price is required.");

            RuleFor(x => x.MinimumLevelQuantity).NotEmpty().WithMessage("Minimum Level Quantity is required.");
            RuleFor(x => x.WarnLevelQuantity).NotEmpty().WithMessage("Warning Level Quantity is required.");
            RuleFor(x => x.MaximumLevelQuantity).NotEmpty().WithMessage("Maximum Level Quantity is required.");

            RuleFor(x => x.OnHandQuantity).NotEmpty().WithMessage("On Hand Quantity is required.");
            RuleFor(x => x.DepartmentType).NotEmpty().WithMessage("Department Type is required.");
        }
    }
}