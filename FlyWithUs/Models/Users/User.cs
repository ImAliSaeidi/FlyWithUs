﻿using FlyWithUs.Hosted.Service.Models.Tickets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Models.Users
{
    public class User : BaseEntity
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            Usertickets = new HashSet<UserTicket>();
        }

        #region Properties
        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; }


        [Required]
        [StringLength(128)]
        public string Email { get; set; }


        [Required]
        [StringLength(128)]
        public string Password { get; set; }


        [Required]
        [StringLength(32)]
        public string Nationality { get; set; }


        [Required]
        [StringLength(128)]
        public string FirstNamePersian { get; set; }


        [Required]
        [StringLength(128)]
        public string LastNamePersian { get; set; }


        [Required]
        [StringLength(128)]
        public string FirstNameEnglish { get; set; }


        [Required]
        [StringLength(128)]
        public string LastNameEnglish { get; set; }


        [Required]
        [StringLength(32)]
        public string NationalityCode { get; set; }


        [Required]
        [StringLength(10)]
        public string Birthdate { get; set; }


        [StringLength(10)]
        public string BirthdateAD { get; set; }


        [Required]
        public string Gender { get; set; }


        [StringLength(32)]
        public string PassportNumber { get; set; }


        [StringLength(10)]
        public string PassportIssunaceDate { get; set; }


        [StringLength(10)]
        public string PassportExpirationDate { get; set; }
        #endregion


        #region Relations
        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<UserTicket> Usertickets { get; set; }

        #endregion

    }
}
