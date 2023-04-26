using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthService _auth;

        public LoginController(AuthService auth)
        {
            _auth = auth;
        }

        public IActionResult Index(string ReturnUrl = null!)
        {
            var model = new UserLoginViewModel();
            if(ReturnUrl != null)
                model.ReturnUrl = ReturnUrl;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.LoginAsync(model))
                    return LocalRedirect(model.ReturnUrl);

                ModelState.AddModelError("", "Incorrect e-mail or password.");
            }
            
            return View(model);
        }
    }
}
