using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductsContext _context;
    private IRepository<Products> _reports;

    public UnitOfWork(ProductsContext context)
    {
        _context = context;
    }

    public IRepository<Products> Reports
    {
        get
        {
            return _reports ??= new ProductsRepository<Products>(_context);
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
