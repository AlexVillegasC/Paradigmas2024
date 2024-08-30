using Shared.Models;

namespace DataLayer.Repositories.Interfaces;

public interface IProductRepository
{
    Task<int> SaveProduct(Products model);
}
