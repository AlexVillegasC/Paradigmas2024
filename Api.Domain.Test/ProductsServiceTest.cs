using Api.Domain.Interfaces;
using Api.Domain.Services;
using Moq;

namespace Api.Domain.Test;

public class ProductsServiceTests
{
    private readonly ProductsService _productsService;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    public ProductsServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _productsService = new ProductsService(_mockUnitOfWork.Object);
    }

    // Reparar UNIT TEST
    [Fact]
    public async Task SaveProductAsync_ShouldReturnProductId_WhenProductIsSavedSuccessfully()
    {
        // Arrange
        var product = new Entities.Products
        {
            Id = 1,
            Description = "Product description",
            Status = true,
            CustomerName = "John Doe",
            CustomerNumber = "12345"
        };

        _mockUnitOfWork.Setup(u => u.Products.AddAsync(It.IsAny<Entities.Products>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _productsService.SaveProductAsync(product);

        // Assert
        _mockUnitOfWork.Verify(u => u.Products.AddAsync(It.IsAny<Entities.Products>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
        Assert.Equal(product.Id, result);
    }

    // Incluir 2 ejemplos más de pruebas unitarias para esta función.

    // Incluir 3 Unit Test para el servicio de paginación de productos.
}
