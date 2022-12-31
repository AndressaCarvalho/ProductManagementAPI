using FluentValidation;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Service.Validators
{
    public class ProviderValidator : AbstractValidator<ProviderEntity>
    {
        public ProviderValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Please enter the description.")
                .NotNull().WithMessage("Please enter the description.");

            RuleFor(p => p.Cnpj)
                .NotEmpty().WithMessage("Please enter the CNPJ.")
                .NotNull().WithMessage("Please enter the CNPJ.");
        }
    }
}
