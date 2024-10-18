using FluentValidation;

namespace ClubFitnessDomain.Validators
{
    public class PosTransactionValidator : AbstractValidator<PosTransaction>
    {
        public PosTransactionValidator()
        {
            RuleFor(x => x.PosTransactionUtcDateTime).NotEmpty().WithMessage("Transaction UTC Date is required.");
            RuleFor(x => x.PosTransactionLocalDateTime).NotEmpty().WithMessage("Transaction Local Date is required.");
            RuleFor(x => x.PosTransactionTotalIncTax).GreaterThan(0).WithMessage("Total Inclusive Tax must be greater than zero.");
            RuleFor(x => x.PosTransactionTotalExTax).GreaterThan(0).WithMessage("Total Exclusive Tax must be greater than zero.");
            RuleFor(x => x.OutstandingBalance).GreaterThanOrEqualTo(0).WithMessage("Outstanding balance cannot be negative.");
        }
    }
}