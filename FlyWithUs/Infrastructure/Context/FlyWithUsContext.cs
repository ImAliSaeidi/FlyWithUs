using FlyWithUs.Models.Airplanes;
using FlyWithUs.Models.Tickets;
using FlyWithUs.Models.Travels;
using FlyWithUs.Models.Users;
using FlyWithUs.Models.World;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Infrastructure.Context
{
    public class FlyWithUsContext : DbContext
    {

        #region Airplanes
        public DbSet<Airplane> Airplanes { get; set; }

        public DbSet<Agancy> Agancies { get; set; }
        #endregion

        #region Tickets
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<UserTicket> UserTickets { get; set; }
        #endregion

        #region Travel
        public DbSet<Travel> Travels { get; set; }

        public DbSet<TravelDetail> TravelDetails { get; set; }

        public DbSet<MultiPartTravel> MultiPartTravels { get; set; }
        #endregion

        #region Users
        public DbSet<User> User { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
        #endregion

        #region World
        public DbSet<Airport> Airports { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }
        #endregion






        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source =LAPTOP-VIV37RCJ\\SQL2019;Initial Catalog=FlyWithUsDB;Integrated Security=true");
        }
    }
}
