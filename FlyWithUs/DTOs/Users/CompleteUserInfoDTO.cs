using System;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class CompleteUserInfoDTO
    {
        public string Id { get; set; }

        [Required(ErrorMessage = UserValidation.RequiredSelectNationalityError)]
        public int NationalityId { get; set; }


        [Required(ErrorMessage = UserValidation.RequiredPersianFirstNameError)]
        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression(UserValidation.PersianCharRegex, ErrorMessage = UserValidation.InvalidFirstNameError)]
        public string FirstNamePersian { get; set; }


        [Required(ErrorMessage = UserValidation.RequiredPersianLastNameError)]
        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression(UserValidation.PersianCharRegex, ErrorMessage = UserValidation.InvalidLastNameError)]
        public string LastNamePersian { get; set; }


        [Required(ErrorMessage = UserValidation.RequiredEnglishFirstNameError)]
        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression(UserValidation.EnglishCharRegex, ErrorMessage = UserValidation.InvalidFirstNameError)]
        public string FirstNameEnglish { get; set; }


        [Required(ErrorMessage = UserValidation.RequiredEnglishLastNameError)]
        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression(UserValidation.EnglishCharRegex, ErrorMessage = UserValidation.InvalidLastNameError)]
        public string LastNameEnglish { get; set; }


        [Required(ErrorMessage = UserValidation.RequiredNationalityCodeError)]
        [StringLength(32, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression(UserValidation.NationalityCodeRegex, ErrorMessage = UserValidation.InvalidNationalityCodeError)]
        public string NationalityCode { get; set; }


        [Required(ErrorMessage = UserValidation.RequiredSelectBirthdateError)]
        public DateTime Birthdate { get; set; }


        [Required(ErrorMessage = UserValidation.RequiredSelectGenderError)]
        public string Gender { get; set; }



        [StringLength(32, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression(UserValidation.PassportNumberRegex, ErrorMessage = UserValidation.InvalidPassportNumberError)]
        public string PassportNumber { get; set; }



        public DateTime? PassportIssunaceDate { get; set; }


        public DateTime? PassportExpirationDate { get; set; }


        public string TravelType { get; set; }
    }
}
