using System.ComponentModel.DataAnnotations;

namespace Asp.netAuth.Models
{
    public class SignupUserModel
    {
        [Required(ErrorMessage ="enter email")]
        [Display(Name ="Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "enter password")]
        [Compare("ConfirmPassword",ErrorMessage ="passsword didnot match")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "enter password")]
     
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
