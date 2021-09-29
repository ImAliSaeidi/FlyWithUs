using AutoMapper;
using FlyWithUs.Hosted.Service.DTOs.Agancies;
using FlyWithUs.Hosted.Service.DTOs.Airplanes;
using FlyWithUs.Hosted.Service.DTOs.Airports;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using FlyWithUs.Hosted.Service.DTOs.Countries;
using FlyWithUs.Hosted.Service.DTOs.Roles;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using FlyWithUs.Hosted.Service.DTOs.Users;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Airplanes;
using FlyWithUs.Hosted.Service.Models.Airplanes;
using FlyWithUs.Hosted.Service.Models.Travels;
using FlyWithUs.Hosted.Service.Models.Users;
using FlyWithUs.Hosted.Service.Models.World;


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

            CreateMap<RoleAddDTO, Role>();
            CreateMap<RoleUpdateDTO, Role>();
            CreateMap<RoleUpdateDTO, Role>().ReverseMap();
            CreateMap<Role, RoleDTO>();

            CreateMap<UserAddDTO, User>();
            CreateMap<UserUpdateDTO, User>();
            CreateMap<UserUpdateDTO, User>().ReverseMap();
            CreateMap<User, UserDTO>();

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
        }
    }
}
