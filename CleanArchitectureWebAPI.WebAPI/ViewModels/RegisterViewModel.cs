using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureWebAPI.WebAPI.ViewModels
{
    public class RegisterViewModel
    {
        [MaxLength(35), Required]
        public string FirstName { get; set; }

        [MaxLength(35), Required]
        public string LastName { get; set; }

        [MaxLength(128), Required]
        public string Password { get; set; }

        [MaxLength(128), Required]
        public string ConfirmPassword { get; set; }

        [MaxLength(255), Required]
        public string Email { get; set; }
    }
}
