using DataLayer.Enums;
using DataLayer.Extensions;

namespace Estate.EndPoint.ViewModels
{
    public class GetEstatesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public int? FloorNumber { get; set; }
        public DocumentTypeEnum Type { get; set; }
        public string DocumentType => Type.GetDisplayName();
    }
}
