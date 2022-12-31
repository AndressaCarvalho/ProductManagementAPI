using ProductManagement.Domain.Entities;

namespace ProductManagement.Domain.Interfaces
{
    public interface IProviderRepository<TEntity> where TEntity : BaseEntity
    {
        IList<ProviderEntity> Select(int? skip, int? take);

        ProviderEntity SelectById(int id);

        void Insert(ProviderEntity obj);

        void Update(ProviderEntity obj);
    }
}