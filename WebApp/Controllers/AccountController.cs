using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly AuthService _auth;

        public AccountController(AuthService auth)
        {
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public async Task<IActionResult> LogOut()
        {
            if (await _auth.LogoutAsync(User))
                return LocalRedirect("/");

            return RedirectToAction("Index");
        }
    }
}
