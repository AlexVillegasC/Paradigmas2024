using Api.Domain.Entities;

namespace Api.Domain.Interfaces;

public interface IProductstService
{
    Task<int> SaveProductAsync(Entities.Products model);
}
