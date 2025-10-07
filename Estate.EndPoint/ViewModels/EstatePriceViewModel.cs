using DataLayer.Enums;
using System.ComponentModel.DataAnnotations;

public class EstatePriceViewModel
{
    [Required]
    public PriceTypeEnum PriceType { get; set; }

    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [Range(0, double.MaxValue, ErrorMessage = "مبلغ باید بزرگتر از صفر باشد")]
    public decimal Amount { get; set; }
}