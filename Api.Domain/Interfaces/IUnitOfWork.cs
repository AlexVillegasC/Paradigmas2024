namespace Api.Domain.Interfaces;

using Api.Domain.Entities;

public interface IUnitOfWork : IDisposable
{
    IRepository<Products> Reports { get; }
    Task<int> CompleteAsync();
}
