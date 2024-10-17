using FluentValidation;

namespace ClubFitnessDomain.Validators
{
    public class PosTransactionItemValidator : AbstractValidator<PosTransactionItem>
    {
        public PosTransactionItemValidator()
        {
            RuleFor(x => x.PosTransactionId).NotEmpty().WithMessage("Transaction ID is required.");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product ID is required.");
            RuleFor(x => x.ItemQuantity).GreaterThan(0).WithMessage("Item quantity must be greater than zero.");
            RuleFor(x => x.ItemPriceExTax).GreaterThanOrEqualTo(0).WithMessage("Item price (ex-tax) must be non-negative.");
            RuleFor(x => x.ItemPriceIncTax).GreaterThanOrEqualTo(0).WithMessage("Item price (inc-tax) must be non-negative.");
            RuleFor(x => x.Discount).GreaterThanOrEqualTo(0).WithMessage("Discount must be non-negative.");
        }
    }
}