namespace Api.Domain.Interfaces;

using Api.Domain.Entities;

public interface IUnitOfWork : IDisposable
{
    IRepository<Products> Products { get; }
    Task<int> CompleteAsync();
}