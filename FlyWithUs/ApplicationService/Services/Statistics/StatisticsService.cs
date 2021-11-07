using FlyWithUs.Hosted.Service.ApplicationService.IServices.Statistics;
using FlyWithUs.Hosted.Service.DTOs.Statistics;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Orders;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Travels;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using System.Linq;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IUserRepository userRepository;
        private readonly IOrderRepository orderRepository;
        private readonly ICityRepository cityRepository;
        private readonly ITravelRepository travelRepository;

        public StatisticsService(IUserRepository userRepository, IOrderRepository orderRepository, ICityRepository cityRepository, ITravelRepository travelRepository)
        {
            this.userRepository = userRepository;
            this.orderRepository = orderRepository;
            this.cityRepository = cityRepository;
            this.travelRepository = travelRepository;
        }

        public StatisticsDTO GetStatistics()
        {
            var dto = new StatisticsDTO();
            dto.UsersCount = userRepository.GetAll().ToList().Count;
            dto.OrdersCount = orderRepository.GetAll().ToList().Count;
            dto.CitiesCount = cityRepository.GetAll().ToList().Count;
            dto.TravelsCount = travelRepository.GetAll().ToList().Count;
            return dto;
        }
    }
}
