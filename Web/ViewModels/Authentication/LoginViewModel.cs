using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Authentication
{
    public class LoginViewModel
    {
        [Display(Name = "Login Email")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(256)]
        [Required(ErrorMessage = "Login Email is required")]
        public string LoginEmail { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MaxLength(64)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]  
        public bool RememberMe { get; set; }
    }
}
