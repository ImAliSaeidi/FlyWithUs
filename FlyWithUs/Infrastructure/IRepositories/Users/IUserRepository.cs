using FlyWithUs.Hosted.Service.Models.Tickets;
using FlyWithUs.Hosted.Service.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users
{
    public interface IUserRepository
    {
        int AddUser(User user);

        int UpdateUser(User user);

        int DeleteUser(int userid);

        User GetUserById(int userid);

        int Save();

        List<User> GetAllUser();

        bool IsPhoneNumberExist(string phonenumber);

        bool IsEmailExist(string email);

        string GetUserNationality(int nationalityid);

        int AddTicket(Ticket ticket);

        int DeleteTicket(int ticketid);

        int UpdateTicket(Ticket ticket);

        List<UserTicket> GetAllUserTicketByUserId(int userid);

        Ticket GetUserTicketByTicketId(int ticketid);

    }
}
