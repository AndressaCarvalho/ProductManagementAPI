using AutoMapper;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.DTOs.Entities;

namespace ProductManagement.Domain.DTOs.Mapping
{
    public class ProviderMapDTO : Profile
    {
        public ProviderMapDTO()
        {
            CreateMap<ProviderEntity, ProviderEntityDTO>().ReverseMap();
        }
    }
}

