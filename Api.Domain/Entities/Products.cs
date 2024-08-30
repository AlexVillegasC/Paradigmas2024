using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities;

[Table("Products", Schema = "dbo")]
public class Products
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool? Status { get; set; }
    public string CustomerName { get; set; }
    public string CustomerNumber { get; set; }
}
