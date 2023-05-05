using WebApp.Models.Dtos;

namespace WebApp.Models.Entities;

public class ProductEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public float Rating { get; set; }
    public string? Description { get; set; }
    public string? AdditionalInfo { get; set; }
    public string? Review { get; set; } = null!;
    public ICollection<ProductImagesEntity> Images { get; set; } = null!;
    public ICollection<ProductCategoryEntity> Categories { get; set; } = null!;
    public ICollection<ProductTagEntity> Tags { get; set; } = null!;

    public static implicit operator Product(ProductEntity entity)
    {
        return new Product
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price,
            Rating = entity.Rating,
            Images = entity.Images,
            Categories = entity.Categories,
            Tags = entity.Tags
        };
    }
}
