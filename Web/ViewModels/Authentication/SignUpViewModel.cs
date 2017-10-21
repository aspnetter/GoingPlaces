using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Authentication
{
    public class SignUpViewModel
    {
        [Display(Name = "Login Email")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(256)]
        [Required(ErrorMessage = "Login Email is required")]
        //[Remote("VerifyEmail", "Account")]
        public string LoginEmail { get; set; }

        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        [MaxLength(256)]
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        [MaxLength(256)]
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MaxLength(64)]
        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }

        [Display(Name = "Password Confirmation")]
        [DataType(DataType.Password)]
        [MaxLength(64)]
        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }
    }
}
