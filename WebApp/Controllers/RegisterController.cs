using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AuthService _auth;
        private readonly UserService _userService;

        public RegisterController(AuthService auth, UserService userService)
        {
            _auth = auth;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel model)
        {
            if (ModelState.IsValid) 
            {
                if (await _auth.ExistUserAsync(x => x.Email == model.Email))
                    ModelState.AddModelError("", "Email is already registered.");

                var user = await _auth.RegisterAsync(model);
                if (user != null)
                {
                    await _userService.UploadImageAsync(user, model.ProfilePicture!);
                    return RedirectToAction("Index");
                }
                           
            }
            return View(model);
        }
    }
}
