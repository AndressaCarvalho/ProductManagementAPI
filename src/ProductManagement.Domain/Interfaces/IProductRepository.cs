using ProductManagement.Domain.Entities;

namespace ProductManagement.Domain.Interfaces
{
    public interface IProductRepository<TEntity> where TEntity : BaseEntity
    {
        IList<ProductEntity> Select(int? skip, int? take);

        ProductEntity SelectById(int id);

        IList<ProductEntity> SelectByStatus(bool status, int? skip, int? take);

        IList<ProductEntity> SelectByProviderId(int providerId, int? skip, int? take);

        void Insert(ProductEntity obj);

        void Update(ProductEntity obj);

        void Delete(ProductEntity obj);
    }
}