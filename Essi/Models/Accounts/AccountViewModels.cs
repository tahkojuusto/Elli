using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Essi.Models
{
    /// <summary>
    /// Form fields of a student shown in the login user interface.
    /// </summary>
    public class LoginViewModel
    {
        [Display(Name = "Student Number")]
        [StringLength(7, MinimumLength = 6)]
        [Required]
        public string StudentNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    /// <summary>
    /// Form fields of a student shown in the registration.
    /// </summary>
    public class RegisterViewModel
    {
        [Display(Name = "Student Number")]
        [StringLength(7, MinimumLength = 6)] // Student numbers are always > 6 chars.
        [Required]
        public string StudentNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
