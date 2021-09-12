using FlyWithUs.Hosted.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Users
{
    public interface IUserService
    {
        bool AddUser(UserAddDTO dto);

        List<UserDTO> GetAllUser();

        bool IsPhoneNumberExist(string phonenumber, int? userid);

        bool IsEmailExist(string email, int? userid);

        UserDTO GetUserById(int userid);

        string GetUserNationality(int nationalityid);

        bool DeleteUser(int userid);

        bool UpdateUser(UserUpdateDTO dto);

        UserUpdateDTO GetUserForUpdate(int userid);

    }
}
