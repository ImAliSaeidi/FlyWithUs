using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Airplanes
{
    public class AirplaneUpdateDTO
    {
        public int Id { get; set; }


        [Required(ErrorMessage = AirplaneValidation.RequiredError)]
        [StringLength(128, ErrorMessage = AirplaneValidation.LengthError)]
        public string Name { get; set; }


        [Required(ErrorMessage = AirplaneValidation.RequiredError)]
        [StringLength(128, ErrorMessage = AirplaneValidation.LengthError)]
        public string Brand { get; set; }


        [Required(ErrorMessage = AirplaneValidation.RequiredError)]
        public int MaxCapacity { get; set; }


        [Required(ErrorMessage = AirplaneValidation.RequiredSelectError)]
        public int AgancyId { get; set; }

    }
}
