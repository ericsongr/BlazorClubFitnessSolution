using FluentValidation;

namespace ClubFitnessDomain.Validators
{
    public class PosTransactionAuditValidator : AbstractValidator<PosTransactionAudit>
    {
        public PosTransactionAuditValidator()
        {
            RuleFor(x => x.PosTransactionId).NotEmpty().WithMessage("Transaction ID is required.");
            RuleFor(x => x.PosTransactionUtcDateTime).NotEmpty().WithMessage("Transaction UTC Date is required.");
            RuleFor(x => x.PosTransactionLocalDateTime).NotEmpty().WithMessage("Transaction Local Date is required.");
            RuleFor(x => x.PosTransactionTotalIncTax).GreaterThanOrEqualTo(0).WithMessage("Total including tax must be non-negative.");
            RuleFor(x => x.PosTransactionTotalExTax).GreaterThanOrEqualTo(0).WithMessage("Total excluding tax must be non-negative.");
            RuleFor(x => x.PosTransactionTotalTax).GreaterThanOrEqualTo(0).WithMessage("Total tax must be non-negative.");
            RuleFor(x => x.ItemQuantity).GreaterThan(0).WithMessage("Item quantity must be greater than zero.");
            RuleFor(x => x.ItemPriceIncTax).GreaterThanOrEqualTo(0).WithMessage("Item price including tax must be non-negative.");
        }
    }
}