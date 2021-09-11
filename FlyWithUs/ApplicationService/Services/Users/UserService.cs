using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.DTOs.Users;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.Users;
using FlyWithUs.Hosted.Service.Models.Users;
using FlyWithUs.Hosted.Service.Tools.Convertors;
using FlyWithUs.Hosted.Service.Tools.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserRepository repository;
        public UserService()
        {
            repository = new UserRepository();
        }

        public bool AddUser(UserAddDTO dto)
        {
            bool result = false;
            int count = repository.AddUser(Map(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public List<UserDTO> GetAllUser()
        {
            List<UserDTO> dtos = new List<UserDTO>();
            foreach (var user in repository.GetAllUser())
            {
                dtos.Add(Map(user));
            }
            return dtos;
        }

        private UserDTO Map(User user)
        {
            return new UserDTO
            {
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Nationality = user.Nationality,
                FirstNamePersian = user.FirstNamePersian,
                LastNamePersian = user.LastNamePersian,
                FirstNameEnglish = user.FirstNameEnglish,
                LastNameEnglish = user.LastNameEnglish,
                NationalityCode = user.NationalityCode,
                Birthdate = user.Birthdate.ToString(),
                Gender = user.Gender
            };
        }

        private User Map(UserAddDTO dto)
        {

            User user = new User
            {
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Password = PasswordHelper.EncodePasswordSHA3(dto.Password),
                Nationality = dto.Nationality,
                FirstNamePersian = dto.FirstNamePersian,
                LastNamePersian = dto.LastNamePersian,
                FirstNameEnglish = dto.FirstNameEnglish,
                LastNameEnglish = dto.LastNameEnglish,
                NationalityCode = dto.NationalityCode,
                BirthdateAD = dto.BirthdateAD.ToShortDateString(),
                Birthdate = Convert.ToDateTime(dto.BirthdateAD.ToShamsi()).ToShortDateString(),
                Gender = dto.Gender
            };
            return user;
        }
    }
}
