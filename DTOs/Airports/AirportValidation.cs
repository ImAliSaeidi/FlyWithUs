namespace FlyWithUs.Hosted.Service.DTOs.Airports
{
    public class AirportValidation
    {
        public const string RequiredPersianNameError = "لطفا نام فارسی فرودگاه را وارد کنید";
        public const string RequiredEnglishNameError = "لطفا نام انگلیسی فرودگاه را وارد کنید";
        public const string RequiredSelectCityError = "لطفا شهر را انتخاب کنید";
        public const string LengthError = "طول مقدار ورودی مجاز نیست";
        public const string InvalidPersianNameError = "نام فارسی وارد شده معتبر نیست";
        public const string InvalidEnglishNameError = "نام انگلیسی وارد شده معتبر نیست";
        public const string PersianNameRegex = "^[0-9آابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی\\s]+$";
        public const string EnglishNameRegex = "^[a-zA-Z0-9\\s]*$";
    }
}
