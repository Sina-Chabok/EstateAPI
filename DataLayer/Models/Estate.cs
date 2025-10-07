using DataLayer.Enums;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataLayer.Models
{
    public class Estate : BaseEntity
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

        public IList<EstateImage> Images { get; set; }

        public IList<EstatePrice> Prices { get; set; } = new List<EstatePrice>();
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
