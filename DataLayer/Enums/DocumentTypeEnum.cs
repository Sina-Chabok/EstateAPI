using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Enums
{
    public enum DocumentTypeEnum : byte
    {
        [Display(Name = "سند رسمی")]
        Deed = 1,
        [Display(Name = "سند قولنامه‌ای")]
        CustomaryOwnership = 2
    }
}
