using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Users;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Users
{
    public interface IUserService
    {
        bool AddUser(UserAddDTO dto);

        void RegisterUser(RegisterDTO dto);

        string LoginUser(LoginDTO dto);

        GridResultDTO<UserDTO> GetAllUser(int skip, int take);

        bool IsPhoneNumberExist(string phoneNumber);

        bool IsPhoneNumberExist(string phoneNumber, string userId);

        bool IsEmailExist(string email);

        bool IsEmailExist(string email, string userId);

        UserDTO GetUserById(string userId);

        bool DeleteUser(string userId);

        bool UpdateUser(UserUpdateDTO dto);

        UserUpdateDTO GetUserForUpdate(string userId);

        bool ChangePassword(ChangePasswordDTO dto);

        bool LoginCheck(string userId);

        UserPanelDTO GetUserForUserPanel(string userId);

        bool Update(UserProfileUpdateDTO dto);

        bool ForgotPassword(ResetPasswordEmailDTO dto);

        bool ForgotPassword(ForgotPasswordDTO dto);

        bool ResetPassword(ResetPasswordDTO dto);
    }
}
