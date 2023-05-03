namespace WebApp.Models.Entities;

public class ProductEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public float Rating { get; set; }
    public virtual ICollection<ProductImagesEntity> Images { get; set; } = null!;
}
