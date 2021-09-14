using FlyWithUs.Hosted.Service.Models.Airplanes;
using FlyWithUs.Hosted.Service.Models.Tickets;
using FlyWithUs.Hosted.Service.Models.Travels;
using FlyWithUs.Hosted.Service.Models.Users;
using FlyWithUs.Hosted.Service.Models.World;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.Context
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
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airplane>()
               .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<Agancy>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<Ticket>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<UserTicket>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<MultiPartTravel>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<Travel>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<TravelDetail>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<Role>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<User>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<UserRole>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<Airport>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<City>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<Country>()
             .HasQueryFilter(u => !u.IsDeleted);
        }
    }
}
