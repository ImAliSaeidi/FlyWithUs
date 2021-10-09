using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.User;
using FlyWithUs.Hosted.Service.DTOs.Users;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users;
using FlyWithUs.Hosted.Service.Models.Users;
using FlyWithUs.Hosted.Service.Tools.Security;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public UserService(IUserRepository repository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.userManager = userManager;
        }


        public bool AddUser(UserAddDTO dto)
        {
            bool result = false;
            var user = mapper.Map<ApplicationUser>(dto);
            user.PasswordHash = HashGenerator.SalterHash(dto.Password);
            user.NormalizedEmail = dto.Email.Trim().ToUpper();
            int count = repository.Add(user);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public bool DeleteUser(string userid)
        {
            bool result = false;
            int count = repository.Delete(userid);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public GridResultDTO<UserDTO> GetAllUser(int skip, int take)
        {
            var dtos = mapper.Map<List<UserDTO>>(repository.GetAll().Skip(skip).Take(take).ToList());
            var count = repository.GetAll().Count();
            foreach (var dto in dtos)
            {
                if (dto.NationalityId != null)
                {
                    dto.Nationality = repository.GetNationality(dto.NationalityId.Value);
                }
            }
            return new GridResultDTO<UserDTO>(count, dtos);
        }

        public UserDTO GetUserById(string userid)
        {
            var user = repository.GetById(userid);
            var dto = mapper.Map<UserDTO>(user);
            if (dto.NationalityId != null)
            {
                dto.Nationality = repository.GetNationality(dto.NationalityId.Value);
            }
            return dto;
        }

        public UserUpdateDTO GetUserForUpdate(string userid)
        {
            var dto = mapper.Map<UserUpdateDTO>(repository.GetById(userid));
            dto.Password = "";
            return dto;
        }

        public bool UpdateUser(UserUpdateDTO dto)
        {
            bool result = false;
            var user = mapper.Map<ApplicationUser>(dto);
            if (dto.Password != null && dto.RePassword != null)
            {
                user.PasswordHash = HashGenerator.SalterHash(dto.Password);
            }
            else
            {
                user.PasswordHash = repository.GetById(dto.Id).PasswordHash;
            }
            user.NormalizedEmail = dto.Email.Trim().ToUpper();
            int count = repository.Update(user);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public bool IsEmailExist(string email)
        {
            return repository.IsEmailExist(email);
        }

        public bool IsEmailExist(string email, string userid)
        {
            bool result = false;
            var user = repository.GetById(userid);
            if (repository.IsEmailExist(email) == true && user.Email != email)
            {
                result = true;
            }
            return result;
        }

        public bool IsPhoneNumberExist(string phonenumber)
        {
            return repository.IsPhoneNumberExist(phonenumber);
        }

        public bool IsPhoneNumberExist(string phonenumber, string userid)
        {
            bool result = false;
            var user = repository.GetById(userid);
            if (repository.IsPhoneNumberExist(phonenumber) == true && user.PhoneNumber != phonenumber)
            {
                result = true;
            }
            return result;
        }

        public void RegisterUser(RegisterDTO dto)
        {
            var user = repository.GetAll()
                .FirstOrDefault(u =>
                u.PhoneNumber == dto.PhoneNumber ||
                u.NormalizedEmail == dto.Email.Trim().ToUpper());
            if (user == null && dto.Rules == true)
            {
                if (dto.Password == dto.RePassword)
                {
                    user = mapper.Map<ApplicationUser>(dto);
                    user.PasswordHash = HashGenerator.SalterHash(dto.Password);
                    user.NormalizedEmail = dto.Email.Trim().ToUpper();
                    int count = repository.Add(user);
                    if (count > 0)
                    {
                        return;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentException();
            }

        }

        public string LoginUser(LoginDTO dto)
        {
            var user = userManager.Users.FirstOrDefault(u => u.PhoneNumber == dto.PhoneNumber);
            if (user != null)
            {
                var hashpass = HashGenerator.SalterHash(dto.Password);
                if (user.PasswordHash == hashpass)
                {
                    return TokenGenerator.Generate(user);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
