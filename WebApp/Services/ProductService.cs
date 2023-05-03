using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;
using WebApp.Models.Identity;
using WebApp.Repositories;
using WebApp.ViewModels;

namespace WebApp.Services;

public class ProductService
{
    private readonly ProductRepository _productRepo;
    private readonly ProductImagesRepository _productImagesRepo;

    public ProductService(ProductRepository productRepo, ProductImagesRepository productImagesRepo)
    {
        _productRepo = productRepo;
        _productImagesRepo = productImagesRepo;
    }

    public async Task<ProductEntity> AddProductAsync(ProductEntity product)
    {
        return await _productRepo.AddAsync(product);       
    }

    public async Task<bool> CreateAsync(ProductAddViewModel model)
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

            foreach (var image in product.Images)
            {
                var imageData = new byte[image.ContentLength];
                //image.InputStream.Read(imageData, 0, image.ContentLength);

                var productImage = new ProductImagesEntity
                {
                    ImageData = imageData,
                    //ImageMimeType = image.ContentType,
                    Product = product
                };

                product.Images.Add(productImage);
            }

            await  _productRepo.AddAsync(product);
            //_dbContext.SaveChanges();


            return false;
        }
        catch { return false; }
    }
}
