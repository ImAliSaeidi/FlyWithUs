namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class UserValidation
    {
        public const string RequiredError = "لطفا آن را وارد کنید";
        public const string RequiredRulesError = "پذیرفتن قوانین الزامیست";
        public const string RequiredEmailError = "لطفا ایمیل را وارد کنید";
        public const string RequiredPasswordError = "لطفا رمزعبور را وارد کنید";
        public const string RequiredRePasswordError = "لطفا تکرار رمزعبور را وارد کنید";
        public const string RequiredPhoneNumberError = "لطفا شماره موبایل را وارد کنید";
        public const string RequiredNationalityCodeError = "لطفا کدملی را وارد کنید";
        public const string RequiredPersianFirstNameError = "لطفا نام فارسی را وارد کنید";
        public const string RequiredEnglishFirstNameError = "لطفا نام انگلیسی را وارد کنید";
        public const string RequiredPersianLastNameError = "لطفا نام خانوادگی فارسی را وارد کنید";
        public const string RequiredEnglishLastNameError = "لطفا نام خانوادگی انگلیسی را وارد کنید";
        public const string PasswordCompareError = "رمزعبور و تکرار آن برابر نیست";
        public const string RequiredReNewPasswordError = "لطفا تکرار رمزعبور جدید را وارد کنید";
        public const string RequiredNewPasswordError = "لطفا رمزعبور جدید را وارد کنید";
        public const string RequiredCurrentPasswordError = "لطفا رمزعبور فعلی را وارد کنید";
        public const string RequiredSelectError = "لطفا آن را انتخاب کنید";
        public const string RequiredSelectGenderError = "لطفا جنسیت را انتخاب کنید";
        public const string RequiredSelectBirthdateError = "لطفا تاریخ تولد را انتخاب کنید";
        public const string RequiredSelectNationalityError = "لطفا ملیت را انتخاب کنید";
        public const string LengthError = "طول مقدار ورودی مجاز نیست";
        public const string InvalidPasswordError = "رمزعبور وارد شده معتبر نیست";
        public const string InvalidEmailError = "ایمیل وارد شده معتبر نیست";
        public const string InvalidPhoneNumberError = "شماره موبایل وارد شده معتبر نیست";
        public const string InvalidPassportNumberError = "شماره پاسپورت وارد شده معتبر نیست";
        public const string InvalidNationalityCodeError = "کدملی وارد شده معتبر نیست";
        public const string InvalidFirstNameError = "نام وارد شده معتبر نیست";
        public const string InvalidLastNameError = "نام خانوادگی وارد شده معتبر نیست";
        public const string PersianCharRegex = "^[آابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی\\s]+$";
        public const string EnglishCharRegex = "^[a-zA-Z\\s]*$";
        public const string PasswordRegex = "^(?=.*\\d)(?=.*[a-z]|[A-Z]).{6,128}$";
        public const string NationalityCodeRegex = "^[0-9]{10}$";
        public const string PassportNumberRegex = "[A-Z|a-z][0-9]{8}$";
        public const string PhoneNumberRegex = "09(0[0-9]|1[0-9]|2[0-9]|3[0-9])[0-9]{3}[0-9]{4}";
    }
}
