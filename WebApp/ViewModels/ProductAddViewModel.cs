using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class ProductAddViewModel
{
    public Guid Id { get; set; }

    [Display(Name = "First Name")]
    [Required(ErrorMessage = "You must enter a product name.")]
    public string Name { get; set; } = null!;

    [Display(Name = "First Name")]
    [Required(ErrorMessage = "You must enter a product price.")]
    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    [Display(Name = "Upload Product Images")]
    [DataType(DataType.Upload)]
    public IFormFile? Images { get; set; }

    public static implicit operator ProductEntity(ProductAddViewModel model)
    {
        return new ProductEntity
        {
            Id = model.Id,
            Name = model.Name,
            Price = model.Price
        };
    }

    public static implicit operator ProductImagesEntity(ProductAddViewModel model)
    {
        return new ProductImagesEntity
        {
            ProductId = model.Id,
        };
    }
}
