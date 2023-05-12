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

        public async Task<IActionResult> LoadMoreProducts(int skip, int take = 8)
        {
            // Load the products with the specified skip and take values
            var products = await _productService.GetAllProductsAsync();

            // Return a partial view with the updated list of products
            return PartialView("_ProductCard", products);
        }

        public IActionResult Privacy()
        {    
            return View();
        }
    }
}