using Asp.netAuth.Models;
using Asp.netAuth.Models.viewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netAuth.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Appuser> signInManager;

        public AccountController( SignInManager<Appuser>signInManager)
        {
            this.signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.username!,model.password!,model.RememberMe,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("","incorrect login attempt");
                return View(model);
            }
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult logout()
        {
            return View();
        }
    }
}
