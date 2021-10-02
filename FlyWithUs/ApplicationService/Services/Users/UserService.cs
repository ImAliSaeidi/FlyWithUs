using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.APIs.User;
using FlyWithUs.Hosted.Service.DTOs.Users;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users;
using FlyWithUs.Hosted.Service.Models;
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
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;

        public UserService(IUserRepository repository, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.userManager = userManager;
        }


        public bool AddUser(UserAddDTO dto)
        {
            bool result = false;
            dto.Password = HashGenerator.SalterHash(dto.Password);
            int count = repository.Add(mapper.Map<User>(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public bool DeleteUser(int userid)
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
                dto.Nationality = repository.GetNationality(dto.NationalityId);
            }
            return new GridResultDTO<UserDTO>(count, dtos);
        }

        public UserDTO GetUserById(int userid)
        {
            var dto = mapper.Map<UserDTO>(repository.GetById(userid));
            dto.Nationality = repository.GetNationality(dto.NationalityId);
            return dto;
        }

        public UserUpdateDTO GetUserForUpdate(int userid)
        {
            var dto = mapper.Map<UserUpdateDTO>(repository.GetById(userid));
            dto.Password = "";
            return dto;
        }

        public bool UpdateUser(UserUpdateDTO dto)
        {
            bool result = false;
            if (dto.Password != null && dto.RePassword != null)
            {
                dto.Password = HashGenerator.SalterHash(dto.Password);
            }
            else
            {
                dto.Password = repository.GetById(dto.Id).Password;
            }
            int count = repository.Update(mapper.Map<User>(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public bool IsEmailExist(string email, int? userid)
        {
            if (userid != null)
            {
                bool result = false;
                var user = repository.GetById(userid.Value);
                if (repository.IsEmailExist(email) == true && user.Email != email)
                {
                    result = true;
                }
                return result;
            }
            else
            {
                return repository.IsEmailExist(email);
            }
        }

        public bool IsPhoneNumberExist(string phonenumber, int? userid)
        {
            if (userid != null)
            {
                bool result = false;
                var user = repository.GetById(userid.Value);
                if (repository.IsPhoneNumberExist(phonenumber) == true && user.PhoneNumber != phonenumber)
                {
                    result = true;
                }
                return result;
            }
            else
            {
                return repository.IsPhoneNumberExist(phonenumber);
            }

        }

        public void RegisterUser(RegisterDTO dto)
        {
            var user = userManager.Users.FirstOrDefault(u => u.PhoneNumber == dto.PhoneNumber);
            if (user == null)
            {
                if (dto.Password == dto.RePassword)
                {
                    var hashpass = HashGenerator.SalterHash(dto.Password);
                    user = new IdentityUser
                    {
                        UserName = dto.PhoneNumber,
                        NormalizedUserName = dto.PhoneNumber.Trim(),
                        Email = dto.Email,
                        NormalizedEmail = dto.Email.Trim().ToUpper(),
                        EmailConfirmed = true,
                        PasswordHash = hashpass,
                        PhoneNumber = dto.PhoneNumber,
                        PhoneNumberConfirmed = true,
                        TwoFactorEnabled = false,
                        LockoutEnabled = false,
                        AccessFailedCount = 0
                    };
                    var rowAffetcted = userManager.CreateAsync(user).Result;
                    if (rowAffetcted.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, AuthorizationRoles.UserRole.ToUpper());
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
