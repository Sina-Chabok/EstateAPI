using DataLayer.Enums;

namespace Application.DTOs
{
    public class InsertEstateDto
    {
        public int Id { get; set; }
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

        public List<InsertEstatePriceDto> Prices { get; set; } = new List<InsertEstatePriceDto>();

    }
    public class InsertEstatePriceDto
    {
        public PriceTypeEnum PriceType { get; set; }
        public decimal Amount { get; set; }
    }
}
