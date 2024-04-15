using System.ComponentModel.DataAnnotations;

namespace Asp.netAuth.Models.viewModel
{
    public class Registervm
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "password not matched")]
        public string Cpassword { get; set; }
        public string Address { get; set; }
    }
}
