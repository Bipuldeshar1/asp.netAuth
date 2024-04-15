using Microsoft.AspNetCore.Identity;

namespace Asp.netAuth.Models
{
    public class Appuser : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
