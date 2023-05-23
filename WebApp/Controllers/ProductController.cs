using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Contexts;
using WebApp.Models.Entities;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ProductController : Controller
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        return RedirectToAction("home", "index");
    }

    // GET: /Product?id={id}
    [HttpGet]
    public async Task<IActionResult> Index(Guid articlenumber)
    {
        var product = await _productService.GetProductAsync(articlenumber);

       

        if (product != null)
        {
            var category = product.Categories.Any();

            var relatedProducts = await _productService.GetAllProductsAsync();

            if (relatedProducts != null)
            {
                var viewModel = new ProductViewModel
                {
                    Product = product,
                    RelatedProducts = relatedProducts
                };
                return View(viewModel);
            }

            return View(product);
        }

        return RedirectToAction("home", "index");
    }
}