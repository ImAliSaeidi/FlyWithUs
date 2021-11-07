using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Users;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using FlyWithUs.Hosted.Service.Models;
using FlyWithUs.Hosted.Service.Models.Users;
using FlyWithUs.Hosted.Service.Tools.Convertors;
using FlyWithUs.Hosted.Service.Tools.EmailSenders;
using FlyWithUs.Hosted.Service.Tools.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;
        private readonly IViewRenderService viewRenderService;

        public UserService(IUserRepository repository, IMapper mapper, ICountryRepository countryRepository, IViewRenderService viewRenderService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.countryRepository = countryRepository;
            this.viewRenderService = viewRenderService;
        }

        public bool AddUser(UserAddDTO dto)
        {
            bool result = false;
            if (IsPhoneNumberExist(dto.PhoneNumber) == false && IsEmailExist(dto.Email) == false)
            {
                var lstUserRoles = new List<ApplicationUserRole>();
                var userRoles = new ApplicationUserRole()
                {
                    RoleId = AuthorizationRoles.UserRoleId
                };
                lstUserRoles.Add(userRoles);
                var user = mapper.Map<ApplicationUser>(dto);
                user.PasswordHash = HashGenerator.SalterHash(dto.Password);
                user.NormalizedEmail = dto.Email.Trim().ToUpper();
                user.ApplicationUserRoles = lstUserRoles;
                int count = repository.Add(user);
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool DeleteUser(string userId)
        {
            bool result = false;
            int count = repository.Delete(userId);
            if (count > 0)
            {
                count = repository.DeleteUserRoles(userId);
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public GridResultDTO<UserDTO> GetAllUser(int skip, int take)
        {
            var users = repository.GetAll().Skip(skip).Take(take).ToList();
            var dtos = new List<UserDTO>();
            var count = repository.GetAll().Count();
            foreach (var item in users)
            {
                var dto = mapper.Map<UserDTO>(item);
                dto.CreateDate = item.CreateDate.ToShamsi();
                if (item.NationalityId != null)
                {
                    dto.Nationality = countryRepository.GetCountryName(item.NationalityId.Value);
                }
                dtos.Add(dto);
            }
            return new GridResultDTO<UserDTO>(count, dtos);
        }

        public UserDTO GetUserById(string userId)
        {
            var user = repository.GetById(userId);
            var dto = mapper.Map<UserDTO>(user);
            if (user.NationalityId != null)
            {
                dto.Nationality = countryRepository.GetCountryName(user.NationalityId.Value);
            }
            if (user.Birthdate != null)
            {
                dto.Birthdate = user.Birthdate.Value.ToString("yyyy/MM/dd").Replace("/", "-");
                dto.ShamsiBirthdate = user.Birthdate.Value.ToShamsi();
            }
            if (user.PassportIssunaceDate != null)
            {
                dto.PassportIssunaceDate = user.PassportIssunaceDate.Value.ToString("yyyy/MM/dd").Replace("/", "-");
            }
            if (user.PassportExpirationDate != null)
            {
                dto.PassportExpirationDate = user.PassportExpirationDate.Value.ToString("yyyy/MM/dd").Replace("/", "-");
            }
            dto.CreateDate = user.CreateDate.ToShamsi();
            return dto;
        }
                
        public bool UpdateUser(UserUpdateDTO dto)
        {
            bool result = false;
            if (IsPhoneNumberExist(dto.PhoneNumber, dto.Id) == false && IsEmailExist(dto.Email, dto.Id) == false)
            {
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
            }
            return result;
        }

        public bool IsEmailExist(string email)
        {
            return repository.IsEmailExist(email);
        }

        public bool IsEmailExist(string email, string userId)
        {
            bool result = false;
            var user = repository.GetById(userId);
            if (repository.IsEmailExist(email) == true && user.Email != email)
            {
                result = true;
            }
            return result;
        }

        public bool IsPhoneNumberExist(string phoneNumber)
        {
            return repository.IsPhoneNumberExist(phoneNumber);
        }

        public bool IsPhoneNumberExist(string phoneNumber, string userId)
        {
            bool result = false;
            var user = repository.GetById(userId);
            if (repository.IsPhoneNumberExist(phoneNumber) == true && user.PhoneNumber != phoneNumber)
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
                    var lstUserRoles = new List<ApplicationUserRole>();
                    var userRoles = new ApplicationUserRole()
                    {
                        RoleId = AuthorizationRoles.UserRoleId
                    };
                    lstUserRoles.Add(userRoles);
                    user = mapper.Map<ApplicationUser>(dto);
                    user.PasswordHash = HashGenerator.SalterHash(dto.Password);
                    user.NormalizedEmail = dto.Email.Trim().ToUpper();
                    user.ApplicationUserRoles = lstUserRoles;
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
            var user = repository.GetAll().FirstOrDefault(u => u.PhoneNumber == dto.PhoneNumber);
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

        public bool ChangePassword(ChangePasswordDTO dto)
        {
            var result = false;
            var user = repository.GetById(dto.Id);
            if (dto.NewPassword == dto.ReNewPassword)
            {
                if (HashGenerator.SalterHash(dto.CurrentPassword) == user.PasswordHash)
                {
                    user.PasswordHash = HashGenerator.SalterHash(dto.NewPassword);
                    int count = repository.Update(user);
                    if (count > 0)
                    {
                        result = true;
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
            return result;
        }

        private  bool CompleteUserInfo(CompleteUserInfoDTO dto)
        {
            bool result = false;
            if (ValidateCompleteUserInfoDTO(dto) == true)
            {
                var olduser = repository.GetById(dto.Id);
                var user = mapper.Map<ApplicationUser>(dto);
                user.PasswordHash = olduser.PasswordHash;
                user.Email = olduser.Email;
                user.NormalizedEmail = olduser.Email.Trim().ToUpper();
                user.PhoneNumber = olduser.PhoneNumber;
                int count = repository.Update(user);
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        private bool UpdateUserProfile(UserProfileUpdateDTO dto)
        {
            bool result = false;

            var user = mapper.Map<ApplicationUser>(dto);
            user.PasswordHash = repository.GetById(dto.Id).PasswordHash;
            user.NormalizedEmail = dto.Email.Trim().ToUpper();
            int count = repository.Update(user);
            if (count > 0)
            {
                result = true;
            }

            return result;
        }

        private static bool ValidateCompleteUserInfoDTO(CompleteUserInfoDTO dto)
        {
            bool result = true;
            if (dto.FirstNamePersian == null)
            {
                result = false;
            }
            else if (dto.LastNamePersian == null)
            {
                result = false;
            }
            else if (dto.FirstNameEnglish == null)
            {
                result = false;
            }
            else if (dto.LastNameEnglish == null)
            {
                result = false;
            }
            else if (dto.NationalityCode == null)
            {
                result = false;
            }
            else if (dto.NationalityId == default)
            {
                result = false;
            }
            else if (dto.Gender == null)
            {
                result = false;
            }
            else if (dto.Birthdate == default)
            {
                result = false;
            }
            else if (dto.TravelType != null)
            {
                if (dto.PassportIssunaceDate == null)
                {
                    result = false;
                }
                else if (dto.PassportExpirationDate == null)
                {
                    result = false;
                }
                else if (dto.PassportNumber == null)
                {
                    result = false;
                }
            }
            return result;
        }

        public bool LoginCheck(string userId)
        {
            var result = false;
            var user = repository.GetById(userId);
            if (user != null)
            {
                result = true;
            }
            return result;
        }

        public UserPanelDTO GetUserForUserPanel(string userId)
        {
            var user = repository.GetById(userId);
            var dto = mapper.Map<UserPanelDTO>(user);
            if (user.Birthdate != null)
            {
                dto.Birthdate = user.Birthdate.Value.ToString("yyyy/MM/dd").Replace("/", "-");
            }
            if (user.PassportIssunaceDate != null)
            {
                dto.PassportIssunaceDate = user.PassportIssunaceDate.Value.ToString("yyyy/MM/dd").Replace("/", "-");
            }
            if (user.PassportExpirationDate != null)
            {
                dto.PassportExpirationDate = user.PassportExpirationDate.Value.ToString("yyyy/MM/dd").Replace("/", "-");
            }
            return dto;
        }

        public bool Update(UserProfileUpdateDTO dto)
        {
            var result = false;
            var userByEmail = repository.GetUserByEmail(dto.Email);
            var userByNumber = repository.GetUserByPhoneNumber(dto.PhoneNumber);
            if (userByEmail.Id == dto.Id && userByNumber.Id == dto.Id)
            {
                if (dto.IsInbuy == false)
                {
                    if (dto.PhoneNumber == null || dto.Email == null)
                    {
                        result = false;
                    }
                    else
                    {
                        result = UpdateUserProfile(dto);
                    }
                }
                else if (dto.IsInbuy == true)
                {
                    result = CompleteUserInfo(mapper.Map<CompleteUserInfoDTO>(dto));
                }
            }
            return result;
        }

        public bool ForgotPassword(ResetPasswordEmailDTO dto)
        {
            var result = false;
            var user = repository.GetUserByEmail(dto.Email);
            if (user != null)
            {
                dto.FullNamePersian = user.FirstNamePersian + " " + user.LastNamePersian;
                user.ActiveCode = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
                dto.ActiveCode = user.ActiveCode;
                dto.RedirectUrl = "http://localhost:4000/auth-reset-password.html";
                repository.Update(user);
                var to = user.Email;
                var subject = "فراموشی رمز عبور";
                var body = viewRenderService.RenderToStringAsync("_ResetPasswordEmail", dto);
                SendEmail.Send(to, subject, body);
                result = true;
            }
            return result;
        }

        public bool ForgotPassword(ForgotPasswordDTO dto)
        {
            var result = false;
            var user = repository.GetUserByEmail(dto.Email);
            if (user != null)
            {
                var edto = new ResetPasswordEmailDTO();
                edto.FullNamePersian = user.FirstNamePersian + " " + user.LastNamePersian;
                user.ActiveCode = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
                edto.ActiveCode = user.ActiveCode;
                edto.RedirectUrl = "http://localhost:3000/reset-password.html";
                repository.Update(user);
                var to = user.Email;
                var subject = "فراموشی رمز عبور";
                var body = viewRenderService.RenderToStringAsync("_ResetPasswordEmail", edto);
                SendEmail.Send(to, subject, body);
                result = true;
            }
            return result;
        }

        public bool ResetPassword(ResetPasswordDTO dto)
        {
            var result = false;
            var user = repository.GetUserByEmail(dto.Email);
            if (user != null)
            {
                if (user.ActiveCode == dto.ActiveCode)
                {
                    user.PasswordHash = HashGenerator.SalterHash(dto.NewPassword);
                    user.ActiveCode = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
                    int count = repository.Update(user);
                    if (count > 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

    }
}

