using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Roles
{
    public class RoleUpdateDTO
    {
        public int Id { get; set; }


        [Display(Name = "نام نقش")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        public string Name { get; set; }

    }
}
