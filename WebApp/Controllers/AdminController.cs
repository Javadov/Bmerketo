using Amazon.IdentityManagement.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApp.Models.Identity;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

[Authorize(Roles = "admin")]
public class AdminController : Controller
{
    private readonly UserService _userService;
    private readonly AuthService _auth;
    private readonly ProductService _productService;
    private readonly TagService _tagService;
    private readonly CategoryService _categoryService;
    private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;


    public AdminController(UserService userService, AuthService auth, ProductService productService, TagService tagService, CategoryService categoryService, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
    {
        _userService = userService;
        _productService = productService;
        _auth = auth;
        _tagService = tagService;
        _categoryService = categoryService;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Users()
    {
        var users = await _userService.GetAllUsersAsync();
        return View(users);
    }

    public IActionResult UserAdd()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UserAdd(UserRegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _auth.ExistUserAsync(x => x.Email == model.Email))
                ModelState.AddModelError("", "Email is already registered.");

            var user = await _auth.RegisterAsync(model);
            if (user != null)
            {
                await _userService.UploadImageAsync(user, model.ProfilePicture!);
                TempData["Message"] = "User is successfully registered.";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Registration failed.");
            }

            return RedirectToAction("users", "admin");
        }

        return View(model);
    }

    public async Task<ActionResult<AppUser>> GetUserByIdAsync(string id)
    {
        var user = await _userService.GetUserAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost("delete/{id}")]
    public async Task<ActionResult> DeleteUser(string id)
    {
        var user = await _userService.GetUserAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        var result = await _userService.DeleteUserAsync(user);
        if (result)
        {
            return Ok();
        }

        return StatusCode(500);
    }

    [HttpPost("make/{id}")]
    public async Task<ActionResult> MakeAdmin(string id)
    {
        var user = await _userService.GetUserAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        var roles = await _userService.GetRolesAsync(user);

        if (roles != "admin")
        {
            // Update the role to "Admin"
            await _userManager.RemoveFromRolesAsync(user, new[] {roles});
            var result = await _userManager.AddToRoleAsync(user, "admin");

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }

        else if (roles == "admin")
        {
            // Update the role to "Admin"
            await _userManager.RemoveFromRolesAsync(user, new[] { roles });
            var result = await _userManager.AddToRoleAsync(user, "user");

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }

        else
        {
            return Ok();
        }        
    }


    public async Task<IActionResult> Products()
    {
        var products = await _productService.GetAllProductsAsync();
        return View(products);
    }

    public async Task<IActionResult> ProductAdd()
    {
        ViewBag.Categories = await _categoryService.GetCategoriesAsync();
        ViewBag.Tags = await _tagService.GetTagsAsync();            
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ProductAdd(ProductAddViewModel model, string[] category, string[] tags)
    {
        if (ModelState.IsValid)
        {
           var product = await _productService.CreateAsync(model);

           if (product != null)
           {
                await _productService.UploadImageAsync(product, model.Image!);
                await _productService.AddCategoryAsync(product, category);
                await _productService.AddTagsAsync(product, tags);
                TempData["Message"] = "Product is successfully added.";
                return RedirectToAction("products");
           }

            ModelState.AddModelError("", "Something went wrong");
        }

        ViewBag.Tags = await _tagService.GetTagsAsync();
        ViewBag.Categories = await _categoryService.GetCategoriesAsync();
        return View(model);
    }
     
}
