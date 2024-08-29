
using Shared.Models;

namespace BusinesLayer.cs.Services.Interfaces;

public interface IProductService
{
    Task<int> SaveProduct(Products product);



}
