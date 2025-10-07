using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;

namespace DataLayer.Models
{
    public class EstatePrice
    {
        public int Id { get; set; }

        public PriceTypeEnum PriceType { get; set; }

        public decimal Amount { get; set; }


        public int EstateId { get; set; }

        public Estate Estate { get; set; }

    }
}
