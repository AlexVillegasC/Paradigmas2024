using AutoMapper;
using Products.Models;

namespace Api.Products.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductsDto, Domain.Entities.Products>();
    }
}