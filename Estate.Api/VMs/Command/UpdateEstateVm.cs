using DataLayer.DTOs;
using DataLayer.Enums;

namespace Estate.Api.VMs.Command
{
    public class UpdateEstateVm
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int? FloorNumber { get; set; }
        public int? UnitNumber { get; set; }
        public bool HasStorage { get; set; }
        public DocumentTypeEnum DocumentType { get; set; }
        public EstateTypeEnum EstateType { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }

        public List<UpdateEstatePriceVm> Prices { get; set; } = [];
    }
}
