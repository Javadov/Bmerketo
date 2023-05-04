using Amazon.SimpleEmail.Model;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Dtos;
using WebApp.Models.Entities;
using WebApp.Models.Identity;
using WebApp.Repositories;
using WebApp.ViewModels;

namespace WebApp.Services;

public class ProductService
{
    private readonly ProductRepository _productRepo;
    private readonly ProductImagesRepository _productImagesRepo;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductService(ProductRepository productRepo, ProductImagesRepository productImagesRepo, IWebHostEnvironment webHostEnvironment)
    {
        _productRepo = productRepo;
        _productImagesRepo = productImagesRepo;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<ProductEntity> AddProductAsync(ProductEntity product)
    {
        return await _productRepo.AddAsync(product);       
    }

    public async Task<Product> CreateAsync(ProductAddViewModel model)
    {
        try
        {
            var product = new ProductEntity
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Price = model.Price,
                Images = new List<ProductImagesEntity>()
            };

            if (model.Image != null && model.Image.Length > 0)
            {
                foreach (var image in model.Image)
                {
                    var imageUrl = $"{product.Id}_{image.FileName.Replace(" ", "_")}";
                    var productImage = new ProductImagesEntity
                    {
                        ProductId = product.Id,
                        ImageUrl = imageUrl
                    };
                    product.Images.Add(productImage);
                }
            }

            await  _productRepo.AddAsync(product);

            return product;
        }
        catch { return null!; }
    }

    public async Task<bool> UploadImageAsync(Product product, IEnumerable<IFormFile> images)
    {
        //try
        //{
        //    string imagePath = $"{_webHostEnvironment.WebRootPath}/images/products/{product.ImageUrl}";
        //    await image.CopyToAsync(new FileStream(imagePath, FileMode.Create));
        //    return true;
        //}
        //catch { return false; }

        try
        {
            foreach (var image in images)
            {
                string imageName = $"{product.Id}_{image.FileName.Replace(" ", "_")}";
                string imagePath = $"{_webHostEnvironment.WebRootPath}/images/products/{imageName}";
                using var stream = new FileStream(imagePath, FileMode.Create);
                await image.CopyToAsync(stream);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}
