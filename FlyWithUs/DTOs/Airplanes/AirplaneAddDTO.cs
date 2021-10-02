using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Airplanes
{
    public class AirplaneAddDTO
    {
        [Display(Name = "نام هواپیما")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        public string Name { get; set; }


        [Display(Name = "برند هواپیما")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        public string Brand { get; set; }


        [Display(Name = "ظرفیت هواپیما")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        public int MaxCapacity { get; set; }


        [Display(Name = "تعداد هواپیما")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        public int Count { get; set; }

        
        [Display(Name = "آژانس هواپیمایی")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public int AgancyId { get; set; }


    }
}
