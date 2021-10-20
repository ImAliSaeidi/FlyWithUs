using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class UserProfileSettingDTO
    {
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstNamePersian { get; set; }

        public string LastNamePersian { get; set; }

        public string FirstNameEnglish { get; set; }

        public string LastNameEnglish { get; set; }

        public string PassportNumber { get; set; }

        public string PassportIssunaceDate { get; set; }

        public string PassportExpirationDate { get; set; }

        public string NationalityCode { get; set; }

        public int? NationalityId { get; set; }

        public string Gender { get; set; }

        public string Birthdate { get; set; }
    }
}
