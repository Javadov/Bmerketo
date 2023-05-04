namespace WebApp.ViewModels;

public class ProductViewModel
{
    public Guid ProductId { get; set; } 
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public float Rating { get; set; }
    public string Description { get; set; } = null!;
    //public string? PhoneNumber { get; set; }
    //public string? Company { get; set; }
    //public string Role { get; set; } = null!;

    //public string? StreetName { get; set; }
    //public string? PostalCode { get; set; }
    //public string? City { get; set; }
    public IEnumerable<ProductImagesViewModel> Images { get; set; } = null!;
    //public IList<string> Roles { get; set; } = null!;
}
