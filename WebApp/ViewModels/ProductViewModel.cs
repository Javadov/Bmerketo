using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class ProductViewModel
{
    public Guid ProductId { get; set; } 
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? AdditionalInfo { get; set; }
    public IEnumerable<ProductImagesViewModel> Images { get; set; } = null!;
    public IEnumerable<ProductCategoryViewModel> Categories { get; set; } = null!;
    public IEnumerable<ProductTagViewModel> Tags { get; set; } = null!;
    public IEnumerable<ProductReviewViewModel> Reviews { get; set; } = null!;
}
