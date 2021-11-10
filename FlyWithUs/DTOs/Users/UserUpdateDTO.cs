using System;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class UserUpdateDTO
    {
        public string Id { get; set; }


        [Required(ErrorMessage = UserValidation.RequiredPhoneNumberError)]
        [StringLength(11, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression(UserValidation.PhoneNumberRegex, ErrorMessage = UserValidation.InvalidPhoneNumberError)]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = UserValidation.RequiredEmailError)]
        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [EmailAddress(ErrorMessage = UserValidation.InvalidEmailError)]
        public string Email { get; set; }


        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression(UserValidation.PasswordRegex, ErrorMessage = UserValidation.InvalidPasswordError)]
        public string Password { get; set; }


        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [Compare("Password", ErrorMessage = UserValidation.PasswordCompareError)]
        public string RePassword { get; set; }


        public int? NationalityId { get; set; }


        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression(UserValidation.PersianCharRegex, ErrorMessage = UserValidation.InvalidFirstNameError)]
        public string FirstNamePersian { get; set; }


        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression(UserValidation.PersianCharRegex, ErrorMessage = UserValidation.InvalidLastNameError)]
        public string LastNamePersian { get; set; }


        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression(UserValidation.EnglishCharRegex, ErrorMessage = UserValidation.InvalidFirstNameError)]
        public string FirstNameEnglish { get; set; }


        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression(UserValidation.EnglishCharRegex, ErrorMessage = UserValidation.InvalidLastNameError)]
        public string LastNameEnglish { get; set; }


        [StringLength(32, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression(UserValidation.NationalityCodeRegex, ErrorMessage = UserValidation.InvalidNationalityCodeError)]
        public string NationalityCode { get; set; }


        public DateTime? Birthdate { get; set; }


        public string Gender { get; set; }


        [StringLength(32, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression(UserValidation.PassportNumberRegex, ErrorMessage = UserValidation.InvalidPassportNumberError)]
        public string PassportNumber { get; set; }


        public DateTime? PassportIssunaceDate { get; set; }


        public DateTime? PassportExpirationDate { get; set; }

    }
}
