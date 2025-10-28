using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class EstateImage : BaseEntity
    {
        public string ImagePath { get; set; }
        public int EstateId { get; set; }
        public Estate Estate { get; set; }

    }
}
