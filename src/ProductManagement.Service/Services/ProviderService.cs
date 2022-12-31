using FluentValidation;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;
using ProductManagement.Infra.CrossCutting.Validators;

namespace ProductManagement.Service.Services
{
    public class ProviderService<TEntity> : IProviderService<TEntity> where TEntity : BaseEntity
    {
        private readonly IProviderRepository<TEntity> _providerRepository;

        public ProviderService(IProviderRepository<TEntity> providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public IList<ProviderEntity> Get(int? skip, int? take) => _providerRepository.Select(skip, take);

        public ProviderEntity GetById(int id) => _providerRepository.SelectById(id);

        public ProviderEntity Add<TValidator>(ProviderEntity obj) where TValidator : AbstractValidator<ProviderEntity>
        {
            if (!string.IsNullOrEmpty(obj.Cnpj))
            {
                if (!ProviderValidator.IsValidCnpj(obj.Cnpj))
                    throw new Exception("Invalid CNPJ!");
            }

            ValidateItem(obj, Activator.CreateInstance<TValidator>());
            _providerRepository.Insert(obj);
            return obj;
        }

        public ProviderEntity Update(ProviderEntity obj)
        {
            if (!string.IsNullOrEmpty(obj.Cnpj))
            {
                if (!ProviderValidator.IsValidCnpj(obj.Cnpj))
                    throw new Exception("Invalid CNPJ!");
            }

            _providerRepository.Update(obj);
            return obj;
        }

        private void ValidateItem(ProviderEntity obj, AbstractValidator<ProviderEntity> validator)
        {
            if (obj == null)
                throw new Exception("Nothing found!");

            validator.ValidateAndThrow(obj);
        }
    }
}
