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

        public UserDTO GetUserById(int userid)
        {
            return Map(repository.GetUserById(userid));
        }

        public string GetUserNationality(int nationalityid)
        {
            return repository.GetUserNationality(nationalityid);
        }

        public bool IsEmailExist(string email)
        {
            return repository.IsEmailExist(email);
        }

        public bool IsPhoneNumberExist(string phonenumber)
        {
            return repository.IsPhoneNumberExist(phonenumber);
        }

        private UserDTO Map(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Nationality = GetUserNationality(user.NationalityId),
                FirstNamePersian = user.FirstNamePersian,
                LastNamePersian = user.LastNamePersian,
                FirstNameEnglish = user.FirstNameEnglish,
                LastNameEnglish = user.LastNameEnglish,
                NationalityCode = user.NationalityCode,
                Birthdate = user.Birthdate,
                BirthdateAD = user.BirthdateAD,
                Gender = user.Gender,
                CreateDate = user.CreateDate,
                PassportNumber = user.PassportNumber,
                PassportIssunaceDate = user.PassportIssunaceDate,
                PassportExpirationDate = user.PassportExpirationDate
            };
        }

        private User Map(UserAddDTO dto)
        {

            User user = new User
            {
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Password = PasswordHelper.EncodePasswordSHA3(dto.Password),
                NationalityId = dto.NtionalityId,
                FirstNamePersian = dto.FirstNamePersian,
                LastNamePersian = dto.LastNamePersian,
                FirstNameEnglish = dto.FirstNameEnglish,
                LastNameEnglish = dto.LastNameEnglish,
                NationalityCode = dto.NationalityCode,
                BirthdateAD = dto.BirthdateAD,
                Birthdate = Convert.ToDateTime(dto.BirthdateAD.ToShamsi()),
                Gender = dto.Gender,
                PassportNumber = dto.PassportNumber
            };
            if (dto.PassportIssunaceDate != null)
            {
                user.PassportIssunaceDate = dto.PassportIssunaceDate.Value.ToShortDateString();
            }
            if (dto.PassportExpirationDate != null)
            {
                user.PassportExpirationDate = dto.PassportExpirationDate.Value.ToShortDateString();
            }
            return user;
        }
    }
}
