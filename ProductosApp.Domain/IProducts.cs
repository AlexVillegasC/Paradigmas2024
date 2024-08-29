
namespace ProductosApp.Domain;

public interface IProducts
{
    Task<List<Productos>> GetProducts();
    Task<int> SaveProduct(Productos command);
}
