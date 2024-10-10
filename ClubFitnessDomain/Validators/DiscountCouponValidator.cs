using FluentValidation;
using ClubFitnessDomain;

namespace ClubFitnessDomain.Validators
{
    public class DiscountCouponValidator : AbstractValidator<DiscountCoupon>
    {
        public DiscountCouponValidator()
        {
            RuleFor(x => x.CouponCode).NotEmpty().WithMessage("Coupon code is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Coupon name is required.");
            RuleFor(x => x.Discount).GreaterThan(0).WithMessage("Discount must be greater than zero.");
            RuleFor(x => x.DiscountType).NotEmpty().WithMessage("Discount type is required.");
            RuleFor(x => x.AccountId).NotEmpty().WithMessage("Please select account.");
            RuleFor(x => x.DiscountFor).NotEmpty().WithMessage("Discount for field is required.");
        }
    }
}