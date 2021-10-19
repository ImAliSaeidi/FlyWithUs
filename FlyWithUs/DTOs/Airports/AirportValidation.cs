using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Airports
{
    public class AirportValidation
    {
        public const string RequiredPersianNameError = "لطفا نام فارسی فرودگاه را وارد کنید";
        public const string RequiredEnglishNameError = "لطفا نام انگلیسی فرودگاه را وارد کنید";
        public const string RequiredSelectError = "لطفا شهر را انتخاب کنید";
        public const string LengthError = "طول مقدار ورودی مجاز نیست";
    }
}
