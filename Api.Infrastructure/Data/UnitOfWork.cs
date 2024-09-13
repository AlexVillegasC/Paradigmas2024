using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductsContext _context;
    private IRepository<Domain.Entities.Products> _products;

    public UnitOfWork(ProductsContext context)
    {
        _context = context;
    }

    public IRepository<Domain.Entities.Products> Products
    {
        get
        {
            return _products ??= new ProductsRepository<Domain.Entities.Products>(_context);
        }
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
