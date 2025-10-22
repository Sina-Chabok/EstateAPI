using DataLayer.Enums;

namespace Estate.Api.VMs.Command
{
    public class UpdateEstatePriceVm
    {
        public PriceTypeEnum PriceType { get; set; }
        public decimal Amount { get; set; }
    }
}
