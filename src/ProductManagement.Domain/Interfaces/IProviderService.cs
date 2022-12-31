using FluentValidation;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Domain.Interfaces
{
    public interface IProviderService<TEntity> where TEntity : BaseEntity
    {
        IList<ProviderEntity> Get(int? skip, int? take);

        ProviderEntity GetById(int id);

        ProviderEntity Add<TValidator>(ProviderEntity obj) where TValidator : AbstractValidator<ProviderEntity>;

        ProviderEntity Update(ProviderEntity obj);
    }
}