using Shared.Models;

namespace DataLayer.Interfaces;

public interface IProductRepository
{
    Task<int> SaveProduct(Products model);
}
