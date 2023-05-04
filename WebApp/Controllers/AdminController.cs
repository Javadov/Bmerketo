using Amazon.IdentityManagement.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApp.Models.Identity;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly UserService _userService;
        private readonly ProductService _productService;
        private readonly AuthService _auth;

        public AdminController(UserService userService, AuthService auth, ProductService productService)
        {
            _userService = userService;
            _productService = productService;
            _auth = auth;
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

                if (await _auth.RegisterAsync(model))
                {
                    TempData["Message"] = "User is successfully registered.";
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

        public async Task<IActionResult> Products()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        public IActionResult ProductAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductAdd(ProductAddViewModel model)
        {
            if (ModelState.IsValid)
            {
               var product = await _productService.CreateAsync(model);

               if (product != null)
               {
                    await _productService.UploadImageAsync(product, model.Image!);
                    return RedirectToAction("products");
               }
                
               ModelState.AddModelError("", "Something went wrong");
            }

            return View(model);
        }
         
    }
}
