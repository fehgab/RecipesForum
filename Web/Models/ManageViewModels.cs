using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace WebPPublished.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class EditProfileViewModel
    {
        [Required(ErrorMessage = "Hiányzik a teljes név.")]
        [Display(Name = "Teljes név")]
        public string DisplayName { get; set; }
        [Required(ErrorMessage = "Hiányzik az Email cím.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Hiányzik a felhasználónév.")]
        [Display(Name = "Felhasználónév")]
        public string UserName { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required(ErrorMessage = "Hiányzik a jelszó.")]
        [StringLength(100, ErrorMessage = "A {0} legalább {2} karkter hosszú legyen.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Új jelszó")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Jelszó újra")]
        [Compare("NewPassword", ErrorMessage = "A jelszavak nem egyeznek meg.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Hiányzik a régi jelszó.")]
        [DataType(DataType.Password)]
        [Display(Name = "Régi jelszó")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Hiányzik az új jelszó.")]
        [StringLength(100, ErrorMessage = "A {0} legalább {2} karkter hosszú legyen.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Új jelszó")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Jelszó újra")]
        [Compare("NewPassword", ErrorMessage = "A jelszavak nem egyeznek meg.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}