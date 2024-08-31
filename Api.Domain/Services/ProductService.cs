using Api.Domain.Data;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class ProductsService : IProduct
{
    public readonly MyDbContext _context;

    public ProductsService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProducts()
    {
        return await _context.Products.ToListAsync(); 
    }

    public async Task<int> SaveReport(Product model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }

     
        _context.Products.Add(model);

        
        await _context.SaveChangesAsync();

        
        return model.Id;
    }
}
