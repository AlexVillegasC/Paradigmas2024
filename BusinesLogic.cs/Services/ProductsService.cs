using DataLayer.cs.Repositories;

using DataLayer.Interfaces;
using BusinesLayer.cs.Services.Interfaces;
using Shared.Models;
public class ProductsService :IProductService


{
    private IProductRepository _productsRepositorye;
    public ProductsService(ProductsRepositorye productsRepositorye)
    {
        _productsRepositorye = productsRepositorye;

    }
    public async Task<int> SaveProduct(Products product)
    {
       return await _productsRepositorye.SaveProduct(product);

    }
}
