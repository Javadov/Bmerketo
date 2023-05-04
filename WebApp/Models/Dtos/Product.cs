using WebApp.Models.Entities;

namespace WebApp.Models.Dtos;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public float Rating { get; set; }
    public virtual ICollection<ProductImagesEntity> Images { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public Guid ProductId { get; set; }
}
