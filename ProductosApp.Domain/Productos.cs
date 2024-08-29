namespace ProductosApp.Domain;
public class Productos
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public IEnumerable<string> Images { get; set; }
}
