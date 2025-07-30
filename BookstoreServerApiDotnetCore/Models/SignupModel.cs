using System.ComponentModel.DataAnnotations;

namespace BookstoreServerApiDotnetCore.Models
{
    public class SignupModel
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [Compare("ConfirmPassword")]
        public required string Password { get; set; }

        [Required]
        public required string ConfirmPassword { get; set; }

    }
}
