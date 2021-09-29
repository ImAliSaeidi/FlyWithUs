using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int NationalityId { get; set; }

        public string Nationality { get; set; }

        public string FirstNamePersian { get; set; }

        public string LastNamePersian { get; set; }

        public string FirstNameEnglish { get; set; }

        public string LastNameEnglish { get; set; }

        public string NationalityCode { get; set; }

        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }

        public DateTime CreateDate { get; set; }

        public string PassportNumber { get; set; }

        public DateTime PassportIssunaceDate { get; set; }

        public DateTime PassportExpirationDate { get; set; }
    }
}
