using System;
using System.Collections.Generic;


namespace Shared.Models;

public class Products
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? Status { get; set; }
    public IEnumerable<string> Images { get; set; }
}
