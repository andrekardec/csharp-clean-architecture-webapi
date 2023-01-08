using CleanArchitectureWebAPI.Application.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWebAPI.Application.ViewModels.User
{
    public class UserViewModel : BaseViewModel
    {
        [MaxLength(35), Required]
        public string FirstName { get; set; }

        [MaxLength(35), Required]
        public string LastName { get; set; }

        [MaxLength(128), Required]
        public string Password { get; set; }

        [MaxLength(255), Required]
        public string Email { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public virtual DateTime CreatedAt { get; set; }

        [Required]
        public virtual DateTime UpdatedAt { get; set; }
    }
}
