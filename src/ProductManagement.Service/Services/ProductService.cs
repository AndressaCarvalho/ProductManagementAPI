using FluentValidation;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;

namespace ProductManagement.Service.Services
{
    public class ProductService<TEntity> : IProductService<TEntity> where TEntity : BaseEntity
    {
        private readonly IProductRepository<TEntity> _productRepository;

        public ProductService(IProductRepository<TEntity> productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<ProductEntity> Get(int? skip, int? take) => _productRepository.Select(skip, take);

        public ProductEntity GetById(int id) => _productRepository.SelectById(id);

        public IList<ProductEntity> GetByStatus(bool status, int? skip, int? take) => _productRepository.SelectByStatus(status, skip, take);

        public IList<ProductEntity> GetByProviderId(int providerId, int? skip, int? take) => _productRepository.SelectByProviderId(providerId, skip, take);

        public ProductEntity Add<TValidator>(ProductEntity obj) where TValidator : AbstractValidator<ProductEntity>
        {
            ValidateItem(obj, Activator.CreateInstance<TValidator>());
            _productRepository.Insert(obj);
            return obj;
        }

        public ProductEntity Update<TValidator>(ProductEntity obj) where TValidator : AbstractValidator<ProductEntity>
        {
            ValidateItem(obj, Activator.CreateInstance<TValidator>());
            _productRepository.Update(obj);
            return obj;
        }

        public void Delete(ProductEntity obj) => _productRepository.Delete(obj);

        private void ValidateItem(ProductEntity obj, AbstractValidator<ProductEntity> validator)
        {
            if (obj == null)
                throw new Exception("Nothing found!");

            validator.ValidateAndThrow(obj);
        }
    }
}
