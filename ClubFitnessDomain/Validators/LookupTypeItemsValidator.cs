using FluentValidation;

namespace ClubFitnessDomain.Validators
{
    public class LookupTypeItemsValidator : AbstractValidator<LookupTypeItem>
    {
        public LookupTypeItemsValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.TypeId).NotNull().WithMessage("TypeId is required.");
        }
    }
}