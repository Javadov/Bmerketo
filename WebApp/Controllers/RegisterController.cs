using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AuthService _auth;

        public RegisterController(AuthService auth)
        {
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel userRegister)
        {
            if (ModelState.IsValid) 
            { 
                if (await _auth.RegisterAsync(userRegister))
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Email is already registered.");
            }
            return View(userRegister);
        }
    }
}
