using DataLayer.Enums;

namespace Estate.Api.VMs.Query
{
    public class GetEstatesQueryVm
    {

        public string? Search { get; set; }

        public DocumentTypeEnum? DocumentType { get; set; }

        public EstateTypeEnum? EstateType { get; set; }

    }
}
