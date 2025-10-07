using System.ComponentModel.DataAnnotations;

namespace DataLayer.Enums
{
    public enum EstateTypeEnum : byte
    {
        [Display(Name = "اپارتمان")]
        Apartment = 1,
        [Display(Name = "ویلا")]
        Villa = 2,
        [Display(Name = "مغازه")]
        Shop = 3,
        [Display(Name = "زمین")]
        Land = 4,
    }
}
