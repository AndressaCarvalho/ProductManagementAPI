using FluentValidation;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Domain.Interfaces
{
    public interface IProductService<TEntity> where TEntity : BaseEntity
    {
        IList<ProductEntity> Get(int? skip, int? take);

        ProductEntity GetById(int id);

        IList<ProductEntity> GetByStatus(bool status, int? skip, int? take);

        IList<ProductEntity> GetByProviderId(int providerId, int? skip, int? take);

        ProductEntity Add<TValidator>(ProductEntity obj) where TValidator : AbstractValidator<ProductEntity>;

        ProductEntity Update<TValidator>(ProductEntity obj) where TValidator : AbstractValidator<ProductEntity>;

        void Delete(ProductEntity obj);
    }
}