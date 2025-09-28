using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookstoreServerApiDotnetCore.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;
    }
}
