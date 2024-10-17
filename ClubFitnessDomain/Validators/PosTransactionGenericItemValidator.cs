using FluentValidation;

namespace ClubFitnessDomain.Validators
{
    public class PosTransactionGenericItemValidator : AbstractValidator<PosTransactionGenericItem>
    {
        public PosTransactionGenericItemValidator()
        {
            RuleFor(x => x.PosTransactionId).NotEmpty().WithMessage("Transaction ID is required.");
            RuleFor(x => x.ItemDescription).NotEmpty().WithMessage("Item description is required.");
            RuleFor(x => x.ItemAmount).GreaterThan(0).WithMessage("Item amount must be greater than zero.");
            RuleFor(x => x.ItemQuantity).GreaterThan(0).WithMessage("Item quantity must be greater than zero.");
            RuleFor(x => x.Discount).GreaterThanOrEqualTo(0).WithMessage("Discount cannot be negative.");
            RuleFor(x => x.DiscountType).NotEmpty().WithMessage("Discount type is required.");
        }
    }
}