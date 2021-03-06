namespace FlyWithUs.Hosted.Service.DTOs.Airplanes
{
    public class AirplaneValidation
    {
        public const string RequiredNameError = "لطفا نام هواپیما را وارد کنید";
        public const string RequiredBrandError = "لطفا برند هواپیما را وارد کنید";
        public const string RequiredMaxCapacityError = "لطفا ظرفیت هواپیما را وارد کنید";
        public const string RequiredSelectAgancyError = "لطفا آژانس هواپیمایی را انتخاب کنید";
        public const string LengthError = "طول مقدار ورودی مجاز نیست";
        public const string InvalidNameError = "نام وارد شده معتبر نیست";
        public const string InvalidBrandError = "برند وارد شده معتبر نیست";
        public const string NameRegex = "[آابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهیa-zA-Z0-9\\s]+$";
        public const string BrandRegex = "[آابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهیa-zA-Z0-9\\s]+$";
    }
}
