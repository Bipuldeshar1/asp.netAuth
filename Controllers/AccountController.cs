using Asp.netAuth.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netAuth.Controllers
{
    public class AccountController:Controller
    {
        [Route("signup")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public IActionResult Index(SignupUserModel userModel)
        {
            if (ModelState.IsValid)
            {

                ModelState.Clear();
            }
            return View();
        }
    }
}
