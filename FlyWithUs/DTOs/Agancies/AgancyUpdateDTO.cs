using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Agancies
{
    public class AgancyUpdateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفا نام آژانس هواپیمایی را وارد کنید")]
        [StringLength(128, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        public string Name { get; set; }
    }
}
