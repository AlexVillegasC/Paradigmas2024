using Shared.Models;

namespace BussinesLayer.Services.Interfaces;

public interface IProductsService
{
    Task<int> SaveProduct(Products product);
}
