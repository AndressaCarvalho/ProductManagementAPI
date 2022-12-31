using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;
using ProductManagement.Infra.Data.Context;
using System.Reflection;

namespace ProductManagement.Infra.Data.Repository
{
    public class ProductRepository<TEntity> : IProductRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ProductManagementContext _dbContext;

        public ProductRepository(ProductManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<ProductEntity> Select(int? skip, int? take)
        {
            var products = _dbContext.Product.ToList();

            if (skip.HasValue)
                products = products.Skip(skip.Value).ToList();

            if (take.HasValue)
                products = products.Take(take.Value).ToList();

            return products;
        }

        public ProductEntity SelectById(int id)
        {
            return _dbContext.Product.FirstOrDefault(p => p.Id == id);
        }

        public IList<ProductEntity> SelectByStatus(bool status, int? skip, int? take)
        {
            var products = _dbContext.Product.Where(p => p.Status == status);

            if (skip.HasValue)
                products = products.Skip(skip.Value);

            if (take.HasValue)
                products = products.Take(take.Value);

            return products.ToList();
        }

        public IList<ProductEntity> SelectByProviderId(int providerId, int? skip, int? take)
        {
            var products = _dbContext.Product.Where(p => p.ProviderId == providerId);

            if (skip.HasValue)
                products = products.Skip(skip.Value);

            if (take.HasValue)
                products = products.Take(take.Value);

            return products.ToList();
        }

        public void Insert(ProductEntity obj)
        {
            _dbContext.Set<ProductEntity>().Add(obj);
            _dbContext.SaveChanges();
        }

        public void Update(ProductEntity obj)
        {
            _dbContext.Product.Attach(obj);
            var entry = _dbContext.Entry(obj);

            Type type = typeof(ProductEntity);
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.Name != "Id" && property.GetValue(obj, null) != null)
                {
                    entry.Property(property.Name).IsModified = true;
                }
            }

            _dbContext.SaveChanges();
        }

        public void Delete(ProductEntity obj)
        {
            _dbContext.Product.Attach(obj);
            _dbContext.Entry(obj).Property(x => x.Status).IsModified = true;
            _dbContext.SaveChanges();
        }
    }
}
