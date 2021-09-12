using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Agancies
{
    public class AgancyAddDTO
    {
        [Required(ErrorMessage = "لطفا نام آژانس هواپیمایی را وارد کنید")]
        [StringLength(128, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        public string Name { get; set; }
    }
}
