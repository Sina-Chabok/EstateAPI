using System.ComponentModel.DataAnnotations;

namespace DataLayer.Enums
{
    public enum PriceTypeEnum : byte
    {
        [Display(Name = "فروش")]

        Sale = 1,
        [Display(Name = "رهن")]

        Mortgage = 2,
        [Display(Name = "اجاره")]

        Rent = 3,
    }
}
