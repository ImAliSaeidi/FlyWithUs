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

        bool IsPhoneNumberExist(string phonenumber);

        bool IsPhoneNumberExist(string phonenumber, string userid);

        bool IsEmailExist(string email);

        bool IsEmailExist(string email, string userid);

        UserDTO GetUserById(string userid);

        UserPanelDTO GetUserForUserPanel(string userid);

        UserCommonInfoDTO GetUserCommonInfo(string userid);

        UserProfileSettingDTO GetUserProfileSetting(string userid);

        bool DeleteUser(string userid);

        bool UpdateUser(UserUpdateDTO dto);

        bool UpdateUserProfile(UserProfileUpdateDTO dto);

        bool CompleteUserInfo(CompleteUserInfoDTO dto);

        UserUpdateDTO GetUserForUpdate(string userid);

        bool ChangePassword(ChangePasswordDTO dto);

        bool LoginCheck(string userid);


    }
}
