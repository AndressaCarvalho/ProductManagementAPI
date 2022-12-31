using FluentValidation;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Service.Validators
{
    public class CreateProductValidator : AbstractValidator<ProductEntity>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Please enter the description.")
                .NotNull().WithMessage("Please enter the description.");

            RuleFor(p => p.ManufacturingDate)
                .NotEmpty().WithMessage("Please enter the manufacturing date.")
                .NotNull().WithMessage("Please enter the manufacturing date.");

            RuleFor(p => p.ProviderId)
                .NotEmpty().WithMessage("Please enter the provider ID.")
                .NotNull().WithMessage("Please enter the provider ID.")
                .Must(p => p > 0)
                .WithMessage("Provider ID must greater than 0.");

            RuleFor(p => p).Must(p => p.ManufacturingDate < p.ExpirationDate)
                .When(p => p.ExpirationDate != null)
                .WithMessage("Expiration date must greater than manufacturing date.");
        }
    }
}
