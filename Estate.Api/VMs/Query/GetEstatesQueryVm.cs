using DataLayer.Enums;

namespace Estate.Api.VMs.Query
{
    public class GetEstatesQueryVm
    {
        public string? Title { get; set; }

        public string? Province { get; set; }

        public string? City { get; set; }

        public DocumentTypeEnum? DocumentType { get; set; }

        public EstateTypeEnum? EstateType { get; set; }

    }
}
