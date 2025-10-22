using DataLayer.Enums;

namespace DataLayer.Querys
{
    public class GetEstatesQuery
    {
        public string? Title { get; set; }

        public string? Province { get; set; }

        public string? City { get; set; }

        public DocumentTypeEnum? DocumentType { get; set; }


        public EstateTypeEnum? EstateType { get; set; }


    }
}
