using System.ComponentModel.DataAnnotations;

namespace EUCTest.ViewModels
{
    public class PersonVm
    {
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "Field is a required")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Field is a required")]
        public string LastName { get; set; } = null!;

        [Display(Name = "IdentityNumber")]
        [RegularExpression("^[0-9]{6,6}/[0-9]{4,4}$", ErrorMessage = "Format not correct")]
        public string? IdentityNumber { get; set; }

        [Display(Name = "Birthdate")]
        [Required(ErrorMessage = "Field is a required")]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Sex")]
        public int SexId { get; set; }

        [Display(Name = "Country")]
        public string CountryId { get; set; } = null!;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Field is a required")]
        [RegularExpression("^\\S+@\\S+\\.\\S+$", ErrorMessage = "Format not correct")]
        public string Email { get; set; } = null;

        [Display(Name = "Gdpr")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "The field must be checked")]
        public bool GdprAgree { get; set; }
    }
}
