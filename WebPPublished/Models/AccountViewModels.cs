using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebPPublished.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Hiányzik az Email cím.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hiányzik a felhasználónév.")]
        [Display(Name = "Felhasználónév")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Hiányzik a teljes név.")]
        [Display(Name = "Teljes név")]
        public string DisplayName { get; set; }
    }

    public class ExternalLoginListViewModel
        {
            public string ReturnUrl { get; set; }
        }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required(ErrorMessage = "Hiányzik a kód.")]
        [Display(Name = "Kód")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Emlékezz rá!")]
        public bool RememberBrowser { get; set; }

        [Display(Name = "Emlékezz rám!")]
        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "Hiányzik az Email cím.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Hiányzik a felhasználónév.")]
        [Display(Name = "Felhasználónév")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Hiányzik a jelszó.")]
        [DataType(DataType.Password)]
        [Display(Name = "Jelszó")]
        public string Password { get; set; }

        [Display(Name = "Emlékezz rám!")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Hiányzik a felhasználónév.")]
        [Display(Name = "Felhasználónév")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Hiányzik az Email cím.")]
        [EmailAddress(ErrorMessage = "nem megfelelő formátumú Email cím.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hiányzik a jelszó.")]
        [StringLength(100, ErrorMessage = "A {0} legalább {2} karkter hosszú legyen.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Jelszó")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Jelszó újra")]
        [Compare("Password", ErrorMessage = "A jelszavak nem egyeznek meg.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Hiányzik a teljes név.")]
        [Display(Name = "Teljes név")]
        public string DisplayName { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Hiányzik az Email cím.")]
        [EmailAddress(ErrorMessage = "nem megfelelő formátumú Email cím.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hiányzik a jelszó.")]
        [StringLength(100, ErrorMessage = "A {0} legalább {2} karkter hosszú legyen.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Jelszó")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Jelszó újra")]
        [Compare("Password", ErrorMessage = "A jelszavak nem egyeznek meg.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Hiányzik az Email cím.")]
        [EmailAddress(ErrorMessage = "nem megfelelő formátumú Email cím.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
