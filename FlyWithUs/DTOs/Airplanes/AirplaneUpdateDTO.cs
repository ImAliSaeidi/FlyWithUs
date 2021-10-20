using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Airplanes
{
    public class AirplaneUpdateDTO
    {
        public int Id { get; set; }


        [Required(ErrorMessage = AirplaneValidation.RequiredNameError)]
        [StringLength(128, ErrorMessage = AirplaneValidation.LengthError)]
        public string Name { get; set; }


        [Required(ErrorMessage = AirplaneValidation.RequiredBrandError)]
        [StringLength(128, ErrorMessage = AirplaneValidation.LengthError)]
        public string Brand { get; set; }


        [Required(ErrorMessage = AirplaneValidation.RequiredMaxCapacityError)]
        public int MaxCapacity { get; set; }


        [Required(ErrorMessage = AirplaneValidation.RequiredSelectAgancyError)]
        public int AgancyId { get; set; }

    }
}
