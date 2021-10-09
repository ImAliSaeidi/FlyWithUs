using FlyWithUs.Hosted.Service.Models;
using FlyWithUs.Hosted.Service.Models.Airplanes;
using FlyWithUs.Hosted.Service.Models.Tickets;
using FlyWithUs.Hosted.Service.Models.Travels;
using FlyWithUs.Hosted.Service.Models.Users;
using FlyWithUs.Hosted.Service.Models.World;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlyWithUs.Hosted.Service.Infrastructure.Context
{
    public class FlyWithUsContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public FlyWithUsContext(DbContextOptions<FlyWithUsContext> option) : base(option)
        {

        }

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
        #endregion

        #region World
        public DbSet<Airport> Airports { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<ApplicationUser>().HasKey(x => x.Id);
            modelBuilder.Entity<ApplicationUser>().HasMany(x => x.ApplicationUserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId);

            modelBuilder.Entity<ApplicationRole>().ToTable("Role");
            modelBuilder.Entity<ApplicationRole>().HasKey(x => x.Id);
            modelBuilder.Entity<ApplicationRole>().HasMany(x => x.ApplicationUserRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<ApplicationUserRole>().ToTable("UserRole");
            modelBuilder.Entity<ApplicationUserRole>().HasOne(x => x.User);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(x => x.Role);


            modelBuilder.Entity<Airplane>()
               .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<Agancy>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<Ticket>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<UserTicket>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<Travel>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<ApplicationUser>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<ApplicationRole>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<ApplicationUserRole>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<Airport>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<City>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<Country>()
             .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<ApplicationRole>()
                .HasData(
                 new ApplicationRole(AuthorizationRoles.UserRole)
                 {
                     Id = AuthorizationRoles.UserRoleId,
                     NormalizedName = AuthorizationRoles.UserRole.ToUpper()
                 },
                  new ApplicationRole(AuthorizationRoles.AdminRole)
                  {
                      Id = AuthorizationRoles.AdminRoleId,
                      NormalizedName = AuthorizationRoles.AdminRole.ToUpper()
                  }
                 );

            modelBuilder.Entity<ApplicationUser>()
                .Ignore(u => u.UserName)
                .Ignore(u => u.NormalizedUserName)
                .Ignore(u => u.ConcurrencyStamp);



            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityRoleClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUserLogin<string>>();
        }
    }
}
