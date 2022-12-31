using FluentAssertions;
using ProductManagement.Infra.CrossCutting.Validators;

namespace ProductManagement.Tests
{
    public class ProviderUnitTests
    {
        [Fact]
        public void ValidateCnpjValid()
        {
            string cnpj = "11819409000150";

            var result = ProviderValidator.IsValidCnpj(cnpj);

            result.Should().Be(true);
        }

        [Fact]
        public void ValidateCnpjInvalidWithRandomDigits()
        {
            string cnpj = "12345678912345";

            var result = ProviderValidator.IsValidCnpj(cnpj);

            result.Should().Be(false);
        }

        [Fact]
        public void ValidateCnpjInvalidWithIncorrectLength()
        {
            string cnpj = "64.773.491/0001-96";

            var result = ProviderValidator.IsValidCnpj(cnpj);

            result.Should().Be(false);
        }
    }
}