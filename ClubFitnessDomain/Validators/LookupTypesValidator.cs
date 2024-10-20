using FluentValidation;

namespace ClubFitnessDomain.Validators
{
    public class LookupTypesValidator : AbstractValidator<LookupType>
    {
        public LookupTypesValidator()
        {
            RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required.");
        }
    }
}