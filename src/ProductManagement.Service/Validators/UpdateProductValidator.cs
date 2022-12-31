using FluentValidation;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Service.Validators
{
    public class UpdateProductValidator : AbstractValidator<ProductEntity>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.ProviderId).Must(p => p > 0)
                .When(p => p.ProviderId != null)
                .WithMessage("Provider ID must greater than 0.");

            RuleFor(p => p).Must(p => p.ManufacturingDate < p.ExpirationDate)
                .When(p => p.ManufacturingDate != null && p.ExpirationDate != null)
                .WithMessage("Expiration date must greater than manufacturing date.");
        }
    }
}
