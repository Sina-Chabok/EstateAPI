using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Errors
{
    public static class EstateError
    {
        public const string TitleIsNull = "تایتل خالی نمیتواند باشد";
        public const string TitleLenghtIsOutOfRange = "طول رشته تایتل کمتر یا بیشتر از حد مجاز است.";
        public const string EstateNotFound = "ملک مورد نظر یافت نشد.";
        public const string DescriptionLenghtIsOutOfRange = "طول رشته توضیحات بیشتر از حد مجاز است.";
        public const string AddressLenghtIsOutOfRange = "طول رشته ادرس بیشتر از حد مجاز است.";
        public const string CityIsNull = "شهر خالی نمیتواند باشد";
        public const string ProvinceIsNull = "استان خالی نمیتواند باشد";
        public const string InvalidDocumentType = "نوع سند معتبر نمی باشد.";
        public const string InvalidEstateType = "نوع ملک معتبر نمی باشد.";
        public const string InvalidTransactionType = "نوع پرداخت معتبر نمی باشد.";
        public const string InvalidRoleType = "نوع سطح دسترسی معتبر نمی باشد.";
    }
}
