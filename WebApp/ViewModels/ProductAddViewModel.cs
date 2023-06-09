﻿using System.ComponentModel.DataAnnotations;
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

    [Display(Name = "Description")]
    public string Description { get; set; } = null!;

    [Display(Name = "Additional Info")]
    public string AdditionalInfo { get; set; } = null!;

    [Display(Name = "Upload Product Images")]
    [Required(ErrorMessage = "You must add any images.")]
    [DataType(DataType.Upload)]
    public IFormFile[]? Image { get; set; }

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
            ImageUrl = $"{model.Id}_{model.Name.Replace(" ", "_")}"
        };
    }
}
