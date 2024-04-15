using Asp.netAuth.Models;
using Asp.netAuth.Models.viewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Controllers;

namespace Asp.netAuth.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Appuser> signInManager;
        private readonly UserManager<Appuser> userManager;

        public AccountController( SignInManager<Appuser>signInManager,UserManager<Appuser> userManager
            )
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
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
        [HttpPost]
        public async Task<IActionResult> Register(Registervm model)
     
        {
            if (ModelState.IsValid)
            {
               
                Appuser user = new Appuser() { 
                    Name=model.Name,
                    UserName=model.Email,
                    Email=model.Email,
                    Address=model.Address
                };
                try
                {
                    var result = await userManager.CreateAsync(user, model.Password!);
                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(user, false);
                        return RedirectToAction("index", "Home");
                    }
                    foreach (var error in result.Errors)
                    {
                        Debug.WriteLine(error.Description);
                        ModelState.AddModelError("", error.Description);
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the exception appropriately
                    Debug.WriteLine($"An error occurred during user creation: {ex.Message}");
                    ModelState.AddModelError("", "An error occurred during user creation.");
                }

            }

            return View();
        }
        public async Task<IActionResult> logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index));
        }
    }
}
