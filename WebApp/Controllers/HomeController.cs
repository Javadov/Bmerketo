using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models.Contexts;
using WebApp.Models.Dtos;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;

        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        public async Task<IActionResult> LoadMoreProducts(int productsToDisplay)
        {
            // Load the products with the specified skip and take values
            var products = await _productService.GetAllProductsAsync();

            var model = products.Take(productsToDisplay);
            // Return a partial view with the updated list of products
            return PartialView("_ProductCard", model);
        }

        public IActionResult Privacy()
        {    
            return View();
        }
    }
}