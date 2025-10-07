using DataLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class User : BaseEntity
    {
        
        public string FullName { get; set; }
       
        public string Email { get; set; }
      
        public string PasswordHash { get; set; }

        public RoleTypeEnum RoleType { get; set; }

        public IList<Estate> Estates { get; set; }
        
    }
}
