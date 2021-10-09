using FlyWithUs.Hosted.Service.Models.Tickets;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Models.Users
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Usertickets = new HashSet<UserTicket>();
            ApplicationUserRoles = new HashSet<ApplicationUserRole>();
            CreateDate = DateTime.Now;
        }

        #region Properties
        public int? NationalityId { get; set; }


        [StringLength(128)]
        public string FirstNamePersian { get; set; }


        [StringLength(128)]
        public string LastNamePersian { get; set; }


        [StringLength(128)]
        public string FirstNameEnglish { get; set; }


        [StringLength(128)]
        public string LastNameEnglish { get; set; }


        [StringLength(32)]
        public string NationalityCode { get; set; }


        public DateTime? Birthdate { get; set; }


        [StringLength(16)]
        public string Gender { get; set; }


        [StringLength(32)]
        public string PassportNumber { get; set; }


        public DateTime? PassportIssunaceDate { get; set; }


        public DateTime? PassportExpirationDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateDate { get; set; }
        #endregion


        #region Relations
        public ICollection<UserTicket> Usertickets { get; set; }

        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
        #endregion

    }
}
