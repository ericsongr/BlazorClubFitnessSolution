using FluentValidation;
using ClubFitnessDomain;

namespace ClubFitnessDomain.Validators
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(s => s.FirstName)
                .NotEmpty()
                .WithMessage("First Name is required.")
                .MaximumLength(100)
                .WithMessage("First Name cannot exceed 100 characters.");

            RuleFor(s => s.LastName)
                .NotEmpty()
                .WithMessage("Last Name is required.")
                .MaximumLength(100)
                .WithMessage("Last Name cannot exceed 100 characters.");

            RuleFor(s => s.MobilePhone)
                .NotEmpty()
                .WithMessage("Mobile Phone is required.")
                .MaximumLength(20)
                .WithMessage("Mobile Phone cannot exceed 20 characters.");

            RuleFor(s => s.Barcode)
                .NotEmpty()
                .WithMessage("Barcode is required.")
                .MaximumLength(10)
                .WithMessage("Barcode cannot exceed 10 characters.");

            RuleFor(s => s.Email)
                .EmailAddress()
                .WithMessage("Please provide a valid email address.")
                .When(s => !string.IsNullOrEmpty(s.Email)).NotEmpty()
                .WithMessage("Email is required.");

            RuleFor(s => s.PosAccessPin)
                .MaximumLength(4)
                .WithMessage("POS Access Pin cannot exceed 4 characters.")
                .When(s => !string.IsNullOrEmpty(s.PosAccessPin));

            RuleFor(s => s.RestrictedIp)
                .MaximumLength(50)
                .WithMessage("Restricted IP cannot exceed 50 characters.")
                .When(s => !string.IsNullOrEmpty(s.RestrictedIp));

            RuleFor(s => s.HourlyRate)
                .NotNull()
                .WithMessage("Hourly Rate is required.");
        }
    }
}
