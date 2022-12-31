using AutoMapper;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.DTOs.Entities;

namespace ProductManagement.Domain.DTOs.Mapping
{
    public class ProductMapDTO : Profile
    {
        public ProductMapDTO()
        {
            CreateMap<ProductEntity, ProductEntityDTO>().ReverseMap();
        }
    }
}

