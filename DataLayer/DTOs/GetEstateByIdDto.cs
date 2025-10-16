using DataLayer.Enums;
using DataLayer.Extensions;

namespace DataLayer.DTOs;

public class GetEstateByIdDto
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

    public string DocumentName => DocumentType.GetDisplayName();

    public EstateTypeEnum EstateType { get; set; }

    public string EstateTypeName => EstateType.GetDisplayName();

    public IList<GetPricesDto> Prices { get; set; }

}