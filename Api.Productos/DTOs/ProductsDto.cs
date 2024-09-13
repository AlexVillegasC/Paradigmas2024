namespace Products.Models;

public class ProductsDto
{
    public string? Description { get; set; }
    public List<Guid> Screenshots { get; set; }
    public bool? Status { get; set; }
    public string CustomerName { get; set; }
    public string CustomerNumber { get; set; }
}
