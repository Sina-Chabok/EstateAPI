using DataLayer.Enums;

namespace Estate.Api.VMs.Command
{
    public class CreateEstatePriceVm
    {
        public PriceTypeEnum PriceType { get; set; }
        public decimal Amount { get; set; }
    }
}
