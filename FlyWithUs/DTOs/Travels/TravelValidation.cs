using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Travels
{
    public class TravelValidation
    {
        public const string RequiredMaxCapacityError = "لطفا حداکثر ظرفیت را وارد کنید";
        public const string RequiredSelectOriginError = "لطفا کشور مبدا را انتخاب کنید";
        public const string LengthError = "طول مقدار ورودی مجاز نیست";
        public const string InvalidInputError = "{0} وارد شده معتبر نیست";
    }
}
