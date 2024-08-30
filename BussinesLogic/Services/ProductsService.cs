using BussinesLayer.Services.Interfaces;
using DataLayer.Repositories.Interfaces;
using Shared.Models;

namespace BussinesLayer.Services;

public class ProductsService : IProductsService
{
    private IProductRepository _productsRepository;

    public ProductsService(IProductRepository productsRepository) 
    {
        _productsRepository = productsRepository;
    }

    public async Task<int> SaveProduct(Products product) 
    {
        return await _productsRepository.SaveProduct(product);
    }

}
