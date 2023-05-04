using WebApp.Models.Dtos;

namespace WebApp.Models.Entities;

public class ProductEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public float Rating { get; set; }
    public ICollection<ProductImagesEntity> Images { get; set; } = null!;

    public static implicit operator Product(ProductEntity entity)
    {
        return new Product
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price,
            Rating = entity.Rating,
            Images = entity.Images
        };
    }
}
