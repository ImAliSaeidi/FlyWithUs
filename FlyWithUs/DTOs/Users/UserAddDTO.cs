using System;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class UserAddDTO
    {
        [Required(ErrorMessage = UserValidation.RequiredPhoneNumberError)]
        [StringLength(11, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression("09(1[0-9]|3[1-9])[0-9]{3}[0-9]{4}", ErrorMessage = UserValidation.InvalidPhoneNumberError)]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = UserValidation.RequiredEmailError)]
        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [EmailAddress(ErrorMessage = UserValidation.InvalidEmailError)]
        public string Email { get; set; }


        [Required(ErrorMessage = UserValidation.RequiredPasswordError)]
        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z]|[A-Z]).{6,128}$", ErrorMessage = UserValidation.InvalidPasswordError)]
        public string Password { get; set; }


        [Required(ErrorMessage = UserValidation.RequiredRePasswordError)]
        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [Compare("Password", ErrorMessage = UserValidation.PasswordCompareError)]
        public string RePassword { get; set; }


        public int? NationalityId { get; set; }


        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression("^[آابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی\\s]+$", ErrorMessage = UserValidation.InvalidFirstNameError)]
        public string FirstNamePersian { get; set; }


        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression("^[آابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی\\s]+$", ErrorMessage = UserValidation.InvalidLastNameError)]
        public string LastNamePersian { get; set; }


        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression("^[a-zA-Z\\s]*$", ErrorMessage = UserValidation.InvalidFirstNameError)]
        public string FirstNameEnglish { get; set; }


        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression("^[a-zA-Z\\s]*$", ErrorMessage = UserValidation.InvalidLastNameError)]
        public string LastNameEnglish { get; set; }


        [StringLength(32, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = UserValidation.InvalidNationalityCodeError)]
        public string NationalityCode { get; set; }


        public DateTime? Birthdate { get; set; }


        public string Gender { get; set; }


        [StringLength(32, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression("[A-Z|a-z][0-9]{8}$", ErrorMessage = UserValidation.InvalidPassportNumberError)]
        public string PassportNumber { get; set; }


        public DateTime? PassportIssunaceDate { get; set; }


        public DateTime? PassportExpirationDate { get; set; }

    }
}
