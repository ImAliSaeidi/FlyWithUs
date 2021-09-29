using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs
{
    public class GridResultDTO<T>
    {
        public GridResultDTO(int count, List<T> data)
        {
            Count = count;
            Data = data;
        }

        public int Count { get; set; }

        public List<T> Data { get; set; }

    }
}
