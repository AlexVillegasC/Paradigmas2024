using MediatR;
using ProductosApp.Domain;

namespace ProductosApp.Application;

public class ProductsQuery
    : IRequest<List<Productos>>
{
}
