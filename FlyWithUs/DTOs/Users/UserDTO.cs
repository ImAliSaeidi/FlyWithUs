using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class UserDTO
    {

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Nationality { get; set; }

        public string FirstNamePersian { get; set; }

        public string LastNamePersian { get; set; }

        public string FirstNameEnglish { get; set; }

        public string LastNameEnglish { get; set; }

        public string NationalityCode { get; set; }

        public string Birthdate { get; set; }

        public string Gender { get; set; }
    }
}
