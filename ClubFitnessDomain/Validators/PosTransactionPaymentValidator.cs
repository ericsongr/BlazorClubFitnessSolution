using FluentValidation;

namespace ClubFitnessDomain.Validators
{
    public class PosTransactionPaymentValidator : AbstractValidator<PosTransactionPayment>
    {
        public PosTransactionPaymentValidator()
        {
            RuleFor(x => x.PosTransactionId).NotEmpty().WithMessage("Transaction ID is required.");
            RuleFor(x => x.PaymentTypeId).NotEmpty().WithMessage("Payment Type is required.");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero.");
            RuleFor(x => x.CCNumber).Length(0, 25).WithMessage("Credit Card Number can't exceed 25 characters.");
        }
    }
}