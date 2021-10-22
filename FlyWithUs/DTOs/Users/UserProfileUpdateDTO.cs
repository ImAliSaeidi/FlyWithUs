using System;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class UserProfileUpdateDTO
    {
        public string Id { get; set; }


        [StringLength(11, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression("09(0[0-9]|1[0-9]|2[0-9]|3[0-9])[0-9]{3}[0-9]{4}", ErrorMessage = UserValidation.InvalidPhoneNumberError)]
        public string PhoneNumber { get; set; }


        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [EmailAddress(ErrorMessage = UserValidation.InvalidEmailError)]
        public string Email { get; set; }


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

        public bool IsInbuy { get; set; }

        public string TravelType { get; set; }
    }
}
