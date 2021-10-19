using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Cities
{
    public class CityValidation
    {
        public const string RequiredPersianNameError = "لطفا نام فارسی شهر را وارد کنید";
        public const string RequiredEnglishNameError = "لطفا نام انگلیسی شهر را وارد کنید";
        public const string RequiredSelectError = "لطفا کشور را انتخاب کنید";
        public const string RequiredImageError = "لطفا تصویر را انتخاب کنید";
        public const string LengthError = "طول مقدار ورودی مجاز نیست";
    }
}
