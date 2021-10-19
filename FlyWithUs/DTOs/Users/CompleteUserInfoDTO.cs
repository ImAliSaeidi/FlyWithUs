﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class CompleteUserInfoDTO
    {
        public string Id { get; set; }

        [Display(Name = "ملیت")]
        public int? NationalityId { get; set; }


        [Display(Name = "نام فارسی")]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        [RegularExpression("^[آابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی]+$", ErrorMessage = CustomDTOValidation.InvalidInput)]
        public string FirstNamePersian { get; set; }


        [Display(Name = "نام خانوادگی فارسی")]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        [RegularExpression("^[آابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی]+$", ErrorMessage = CustomDTOValidation.InvalidInput)]
        public string LastNamePersian { get; set; }


        [Display(Name = "نام انگلیسی")]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = CustomDTOValidation.InvalidInput)]
        public string FirstNameEnglish { get; set; }


        [Display(Name = " نام خانوادگی انگلیسی")]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = CustomDTOValidation.InvalidInput)]
        public string LastNameEnglish { get; set; }


        [Display(Name = "کدملی")]
        [StringLength(32, ErrorMessage = CustomDTOValidation.Length)]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = CustomDTOValidation.InvalidInput)]
        public string NationalityCode { get; set; }


        [Display(Name = " تاریخ تولد")]
        public DateTime? Birthdate { get; set; }


        [Display(Name = "جنسیت")]
        public string Gender { get; set; }


        [Display(Name = "شماره گذرنامه")]
        [StringLength(32, ErrorMessage = CustomDTOValidation.Length)]
        [RegularExpression("[A-Z|a-z][0-9]{8}$", ErrorMessage = CustomDTOValidation.InvalidInput)]
        public string PassportNumber { get; set; }



        public DateTime? PassportIssunaceDate { get; set; }


        public DateTime? PassportExpirationDate { get; set; }
    }
}
