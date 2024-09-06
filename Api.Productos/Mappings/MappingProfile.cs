using Api.Domain.Entities;
using AutoMapper;
using Reports.Models;

namespace ChatBot_Test.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductsDto, Products>();
    }
}