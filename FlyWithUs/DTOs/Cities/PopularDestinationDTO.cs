using FlyWithUs.Hosted.Service.Models;

namespace FlyWithUs.Hosted.Service.DTOs.Cities
{
    public class PopularDestinationDTO
    {
        public string PersianName { get; set; }

        private string imagePath;

        public string ImagePath
        {
            get { return CDNConfiguration.HttpUrl + imagePath; }
            set { imagePath = value; }
        }
    }
}
