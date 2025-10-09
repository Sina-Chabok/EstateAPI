using DataLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace Estate.EndPoint.ViewModels
{
    public class EstatePriceViewModel
    {
        public int Id { get; set; }

        [Required] public PriceTypeEnum PriceType { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Range(0, double.MaxValue, ErrorMessage = "مبلغ باید بزرگتر از صفر باشد")]
        public decimal Amount { get; set; }
    }
}