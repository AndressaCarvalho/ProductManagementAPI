using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;
using ProductManagement.Infra.Data.Context;
using System.Reflection;

namespace ProductManagement.Infra.Data.Repository
{
    public class ProviderRepository<TEntity> : IProviderRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ProductManagementContext _dbContext;

        public ProviderRepository(ProductManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<ProviderEntity> Select(int? skip, int? take)
        {
            var providers = _dbContext.Provider.ToList();

            if (skip.HasValue)
                providers = providers.Skip(skip.Value).ToList();

            if (take.HasValue)
                providers = providers.Take(take.Value).ToList();

            return providers;
        }

        public ProviderEntity SelectById(int id)
        {
            return _dbContext.Provider.FirstOrDefault(p => p.Id == id);
        }

        public void Insert(ProviderEntity obj)
        {
            _dbContext.Set<ProviderEntity>().Add(obj);
            _dbContext.SaveChanges();
        }

        public void Update(ProviderEntity obj)
        {
            _dbContext.Provider.Attach(obj);
            var entry = _dbContext.Entry(obj);

            Type type = typeof(ProviderEntity);
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
    }
}
