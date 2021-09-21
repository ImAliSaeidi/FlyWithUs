using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users;
using FlyWithUs.Hosted.Service.Models.Tickets;
using FlyWithUs.Hosted.Service.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly FlyWithUsContext context;

        public UserRepository(FlyWithUsContext context)
        {
            this.context = context;
        }

        public int AddTicket(Ticket ticket)
        {
            context.Tickets.Add(ticket);
            return Save();
        }

        public int AddUser(User user)
        {
            context.User.Add(user);
            return Save();
        }

        public int DeleteTicket(int ticketid)
        {
            var ticket = GetUserTicketByTicketId(ticketid);
            ticket.IsDeleted = true;
            return UpdateTicket(ticket);
        }

        public int DeleteUser(int userid)
        {
            var user = GetUserById(userid);
            user.IsDeleted = true;
            return UpdateUser(user);
        }

        public List<User> GetAllUser()
        {
            return context.User.ToList();
        }

        public List<UserTicket> GetAllUserTicketByUserId(int userid)
        {
            return context.UserTickets.Where(u => u.User.Id == userid).ToList();
        }

        public User GetUserById(int userid)
        {
            return context.User.Find(userid);
        }

        public string GetUserNationality(int nationalityid)
        {
            return context.Countries.Find(nationalityid).NiceName;
        }

        public Ticket GetUserTicketByTicketId(int ticketid)
        {
            return context.Tickets.Find(ticketid);
        }

        public bool IsEmailExist(string email)
        {
            return context.User.Any(u => u.Email == email);
        }

        public bool IsPhoneNumberExist(string phonenumber)
        {
            return context.User.Any(u => u.PhoneNumber == phonenumber);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int UpdateTicket(Ticket ticket)
        {
            context.Tickets.Update(ticket);
            return Save();
        }

        public int UpdateUser(User user)
        {
            context.User.Update(user);
            return Save();
        }

    }
}
