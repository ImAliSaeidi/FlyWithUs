using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.User;
using FlyWithUs.Hosted.Service.DTOs.Users;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Users
{
    public interface IUserService
    {
        bool AddUser(UserAddDTO dto);

        void RegisterUser(RegisterDTO dto);

        string LoginUser(LoginDTO dto);

        GridResultDTO<UserDTO> GetAllUser(int skip, int take);

        bool IsPhoneNumberExist(string phonenumber);

        bool IsPhoneNumberExist(string phonenumber, string userid);

        bool IsEmailExist(string email);

        bool IsEmailExist(string email, string userid);

        UserDTO GetUserById(string userid);

        bool DeleteUser(string userid);

        bool UpdateUser(UserUpdateDTO dto);

        UserUpdateDTO GetUserForUpdate(string userid);

    }
}
