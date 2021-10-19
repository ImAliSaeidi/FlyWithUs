using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Countries
{
    public class CountryValidation
    {
        public const string RequiredPersianNameError = "لطفا نام فارسی کشور را وارد کنید";
        public const string RequiredEnglishNameError = "لطفا نام انگلیسی کشور را وارد کنید";
        public const string LengthError = "طول مقدار ورودی مجاز نیست";
    }
}
