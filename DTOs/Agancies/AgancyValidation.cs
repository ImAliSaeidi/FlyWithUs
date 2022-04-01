namespace FlyWithUs.Hosted.Service.DTOs.Agancies
{
    public class AgancyValidation
    {
        public const string RequiredNameError = "لطفا نام آژانس هواپیمایی را وارد کنید";
        public const string LengthError = "طول مقدار ورودی مجاز نیست";
        public const string InvalidNameError = "نام وارد شده معتبر نیست";
        public const string NameRegex = "[آابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهیa-zA-Z0-9\\s]+$";
    }
}
