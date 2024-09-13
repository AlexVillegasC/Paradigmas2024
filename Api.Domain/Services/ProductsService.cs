using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Services;
public class ProductsService : IProductstService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> SaveProductAsync(Entities.Products model)
    {
        var product = new Entities.Products
        {            
            Description = string.IsNullOrWhiteSpace(model.Description) ? null : model.Description,
            Status = model.Status,
            CustomerName = string.IsNullOrWhiteSpace(model.CustomerName) ? null : model.CustomerName,
            CustomerNumber = string.IsNullOrWhiteSpace(model.CustomerNumber) ? null : model.CustomerNumber
        };

        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.CompleteAsync();

        return product.Id;
    }
}
