using System.ComponentModel.DataAnnotations;
using WebApp.Models.Dtos;
namespace WebApp.Models.Entities;

public class ProductEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? AdditionalInfo { get; set; }    
    public ICollection<ProductImagesEntity> Images { get; set; } = new HashSet<ProductImagesEntity>();
    public ICollection<ProductCategoryEntity> Categories { get; set; } = new HashSet<ProductCategoryEntity>();
    public ICollection<ProductTagEntity> Tags { get; set; } = new HashSet<ProductTagEntity>();
    public ICollection<ProductReviewsEntity> Reviews { get; set; } = new HashSet<ProductReviewsEntity>();

    public static implicit operator Product(ProductEntity entity)
    {
        return new Product
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price,
            Description = entity.Description!,
            AdditionalInfo = entity.AdditionalInfo!,
            Images = entity.Images,
            Categories = entity.Categories,
            Tags = entity.Tags,
            Reviews = entity.Reviews,
        };
    }
}
