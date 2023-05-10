using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Contexts;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ProductController : Controller
{
    private readonly DataContext db;

    public ProductController(DataContext db)
    {
        this.db = db;
    }

    public IActionResult Index(Guid ID)
    {

        //ProductsViewModel model = new ProductsViewModel();
        //model.Product = db.Products.Where(x => x.Id = ID);

        return View();
    }
}
