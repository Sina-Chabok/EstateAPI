using System.ComponentModel.DataAnnotations;

namespace DataLayer.Enums
{
    public enum TransactionTypeEnum : byte
    {
        [Display(Name = "رهن")]

        Mortgage = 1,
        [Display(Name = "اجاره")]

        Rent = 2,
        [Display(Name = "فروش")]

        Sale = 3,
    }
}
