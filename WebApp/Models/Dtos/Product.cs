using WebApp.Models.Entities;

namespace WebApp.Models.Dtos;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Description { get; set; } = null!;
    public string AdditionalInfo { get; set; } = null!;
    public virtual ICollection<ProductImagesEntity> Images { get; set; } = null!;
    public ICollection<ProductCategoryEntity> Categories { get; set; } = null!;
    public ICollection<ProductTagEntity> Tags { get; set; } = null!;
    public ICollection<ProductReviewsEntity> Reviews { get; set; } = new HashSet<ProductReviewsEntity>();
    public string? ImageUrl { get; set; }
    public string? Review { get; set; }
    public float Rating { get; set; }
    public Guid ProductId { get; set; }
    public List<Product>? RelatedProducts { get; set; }
}
