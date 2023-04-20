using System.ComponentModel.DataAnnotations;

namespace EUCTest.Enums
{
    public enum SexEnum
    {
        [Display(Name = "Male")]
        Male = 1,
        [Display(Name = "Female")]
        Female,
    }
}
