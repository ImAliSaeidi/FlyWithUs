using AutoMapper;
using FlyWithUs.Hosted.Service.DTOs.Agancies;
using FlyWithUs.Hosted.Service.DTOs.Airplanes;
using FlyWithUs.Hosted.Service.DTOs.Airports;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using FlyWithUs.Hosted.Service.DTOs.Countries;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using FlyWithUs.Hosted.Service.DTOs.Users;
using FlyWithUs.Hosted.Service.Models.Airplanes;
using FlyWithUs.Hosted.Service.Models.Travels;
using FlyWithUs.Hosted.Service.Models.Users;
using FlyWithUs.Hosted.Service.Models.World;
using FlyWithUs.Hosted.Service.Models.Orders;
using FlyWithUs.Hosted.Service.DTOs.Orders;

namespace FlyWithUs.Hosted.Service.Infrastructure.Common
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<AgancyAddDTO, Agancy>();
            CreateMap<AgancyUpdateDTO, Agancy>();
            CreateMap<AgancyUpdateDTO, Agancy>().ReverseMap();
            CreateMap<Agancy, AgancyDTO>();

            CreateMap<AirplaneAddDTO, Airplane>();
            CreateMap<AirplaneUpdateDTO, Airplane>();
            CreateMap<AirplaneUpdateDTO, Airplane>().ReverseMap();
            CreateMap<Airplane, AirplaneDTO>();

            CreateMap<TravelAddDTO, Travel>();
            CreateMap<TravelUpdateDTO, Travel>();
            CreateMap<TravelUpdateDTO, Travel>().ReverseMap();
            CreateMap<Travel, TravelDTO>();
            CreateMap<Travel, TravelView>();
            CreateMap<TravelView, TravelViewDTO>();
            CreateMap<PopularDestinationView, PopularDestinationDTO>();

            CreateMap<UserAddDTO, ApplicationUser>();
            CreateMap<UserUpdateDTO, ApplicationUser>();
            CreateMap<CompleteUserInfoDTO, ApplicationUser>();
            CreateMap<UserUpdateDTO, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, UserDTO>();
            CreateMap<ApplicationUser, UserPanelDTO>();
            CreateMap<UserProfileUpdateDTO, ApplicationUser>();
            CreateMap<ApplicationUser, UserCommonInfoDTO>();
            CreateMap<ApplicationUser, UserProfileSettingDTO>();

            CreateMap<AirportAddDTO, Airport>();
            CreateMap<AirportUpdateDTO, Airport>();
            CreateMap<AirportUpdateDTO, Airport>().ReverseMap();
            CreateMap<Airport, AirportDTO>();

            CreateMap<CityAddDTO, City>();
            CreateMap<CityUpdateDTO, City>();
            CreateMap<CityUpdateDTO, City>().ReverseMap();
            CreateMap<City, CityDTO>();

            CreateMap<CountryAddDTO, Country>();
            CreateMap<CountryUpdateDTO, Country>();
            CreateMap<CountryUpdateDTO, Country>().ReverseMap();
            CreateMap<Country, CountryDTO>();
            CreateMap<Country, CountryListDTO>();

            CreateMap<RegisterDTO, ApplicationUser>();
            CreateMap<RegisterDTO, ApplicationUser>().ReverseMap();

            CreateMap<PaymentResultView, PaymentResultDTO>();

        }
    }
}
