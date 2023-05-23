using Amazon.EC2.Model;
using Amazon.SimpleEmail.Model;
using Microsoft.EntityFrameworkCore;
using WebApp.Migrations.Data;
using WebApp.Models.Contexts;
using WebApp.Models.Dtos;
using WebApp.Models.Entities;
using WebApp.Repositories;
using WebApp.ViewModels;

namespace WebApp.Services;

public class ProductService
{
    private readonly ProductRepository _productRepo;
    private readonly ProductImagesRepository _productImagesRepo;
    private readonly ProductTagRepository _productTagRepo;
    private readonly ProductCategoryRepository _productCategoryRepo;
    private readonly DataContext _dataContext;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductService(ProductRepository productRepo, ProductImagesRepository productImagesRepo, IWebHostEnvironment webHostEnvironment, DataContext dataContext, ProductTagRepository productTagRepo, ProductCategoryRepository productCategoryRepo)
    {
        _productRepo = productRepo;
        _productImagesRepo = productImagesRepo;
        _webHostEnvironment = webHostEnvironment;
        _dataContext = dataContext;
        _productTagRepo = productTagRepo;
        _productCategoryRepo = productCategoryRepo;
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
                Description = model.Description,
                AdditionalInfo = model.AdditionalInfo,
                Images = new List<ProductImagesEntity>()
            };

            if (model.Image != null && model.Image.Length > 0)
            {
                foreach (var image in model.Image)
                {
                    var imageUrl = $"{product.Id}_{Path.GetFileName(image.FileName).Replace(" ", "_")}";
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
        try
        {
            foreach (var image in images)
            {
                string imageName = $"{product.Id}_{Path.GetFileName(image.FileName).Replace(" ", "_")}";
                string imagePath = $"{_webHostEnvironment.WebRootPath}/images/products/{imageName}";
                using var stream = new FileStream(imagePath, FileMode.Create);
                await image.CopyToAsync(stream);
            }
            return true;
        }
        catch {return false;}
    }

    public async Task AddTagsAsync(Product product, string[] tags)
    {
        foreach(var tag in tags)
        {
            await _productTagRepo.AddAsync(new ProductTagEntity
            {
                ProductId = product.Id,
                TagId = int.Parse(tag)
            });
        }
    }

    public async Task AddCategoryAsync(Product product, string[] categories)
    {
        foreach (var category in categories)
        {
            await _productCategoryRepo.AddAsync(new ProductCategoryEntity
            {
                ProductId = product.Id,
                CategoryId = int.Parse(category)
            });
        }
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
    {
        var products = new List<ProductViewModel>();

        var _products = await _productRepo.GetAllAsync();

        foreach (var product in _products)
        {
            var categories = await _dataContext.ProductCategories.Where(x => x.ProductId == product.Id).Select(x => x.Category).ToListAsync();
            var tags = await _dataContext.ProductTags.Where(x => x.ProductId == product.Id).Select(x => x.Tag).ToListAsync();
            var images = await _dataContext.ProductImages.Where(x => x.ProductId == product.Id).Select(x => x.ImageUrl).ToListAsync();

            var productViewModel = new ProductViewModel
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                Images = images.Select(i => new ProductImagesViewModel
                {
                    ImageUrl = i!
                }),
                Categories = categories.Select(c => new ProductCategoryViewModel
                {
                    Id = _dataContext.ProductCategories.FirstOrDefault(pc => pc.ProductId == product.Id && pc.Category == c)?.CategoryId ?? 0,
                    Category = c.Category
                }),
                Tags = tags.Select(t => new ProductTagViewModel
                {
                    Tag = t.Tag
                })
            };

            products.Add(productViewModel);

        }

        return products;
    }

    public async Task<IEnumerable<ProductViewModel>> GetProductsByCategoryAsync(CategoryEntity category)
    {
        var products = new List<ProductViewModel>();

        var categoryProducts = await _dataContext.ProductCategories.Where(x => x.Category == category).Select(x => x.ProductId).ToListAsync();

        var _products = await _productRepo.GetAllAsync();

        foreach (var product in _products)
        {
            if (categoryProducts.Contains(product.Id))
            {
                var categories = await _dataContext.ProductCategories
                    .Where(x => x.ProductId == product.Id)
                    .Select(x => x.Category)
                    .ToListAsync();

                var tags = await _dataContext.ProductTags
                    .Where(x => x.ProductId == product.Id)
                    .Select(x => x.Tag)
                    .ToListAsync();

                var images = await _dataContext.ProductImages
                    .Where(x => x.ProductId == product.Id)
                    .Select(x => x.ImageUrl)
                    .ToListAsync();

                var productViewModel = new ProductViewModel
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Images = images.Select(i => new ProductImagesViewModel
                    {
                        ImageUrl = i!
                    }),
                    Categories = categories.Select(c => new ProductCategoryViewModel
                    {
                        Category = c.Category
                    }),
                    Tags = tags.Select(t => new ProductTagViewModel
                    {
                        Tag = t.Tag
                    })
                };

                products.Add(productViewModel);
            }
        }

        return products;
    }


    //public async Task<ProductViewModel> GetProductAsync(Guid id)
    //{
    //    var product = new ProductViewModel();

    //    var _product = await _productRepo.GetAsync(p => p.Id == id);
    //    if (_product == null)
    //        product.Add(_product);

    //    return product;
    //}

    public async Task<ProductViewModel> GetProductAsync(Guid id)
    {
        var product = await _productRepo.GetAsync(p => p.Id == id);

        var categories = await _dataContext.ProductCategories.Where(x => x.ProductId == id).Select(x => x.Category).ToListAsync();
        var tags = await _dataContext.ProductTags.Where(x => x.ProductId == id).Select(x => x.Tag).ToListAsync();
        var images = await _dataContext.ProductImages.Where(x => x.ProductId == id).Select(x => x.ImageUrl).ToListAsync();

        var productViewModel = new ProductViewModel
        {
            ProductId = product.Id,
            Name = product.Name,
            Price = product.Price,
            Images = images.Select(i => new ProductImagesViewModel
            {
                ImageUrl = i!
            }),
            Categories = categories.Select(c => new ProductCategoryViewModel
            {
                Category = c.Category
            }),
            Tags = tags.Select(t => new ProductTagViewModel
            {
                Tag = t.Tag
            })
        };

        return productViewModel;
    }
}
