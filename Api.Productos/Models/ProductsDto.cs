namespace Reports.Models;

public class ProductsDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? Status { get; set; }
    public IEnumerable<string> Images { get; set; }
}
