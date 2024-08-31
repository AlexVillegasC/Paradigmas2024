using Api.Domain.Entities;
using Api.Productos.DTOs;
using AutoMapper;

namespace Api.Productos.Mapping
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile() 
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
        }
    }
}
