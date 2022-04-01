namespace FlyWithUs.Hosted.Service.DTOs.Airports
{
    public class AirportDTO
    {
        public int Id { get; set; }

        public string PersianName { get; set; }

        public string EnglishName { get; set; }

        public string CityName { get; set; }

        public int CityId { get; set; }

        public int CountryId { get; set; }
    }
}
