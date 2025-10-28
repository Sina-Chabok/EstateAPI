using DataLayer.Enums;

namespace DataLayer.Querys
{
    public class GetEstatesQuery
    {
        public string? Search { get; set; }

        public DocumentTypeEnum? DocumentType { get; set; }


        public EstateTypeEnum? EstateType { get; set; }


    }
}
