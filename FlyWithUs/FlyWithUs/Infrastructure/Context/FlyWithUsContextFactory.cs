using FlyWithUs.Hosted.Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FlyWithUs.Hosted.Service.Infrastructure.Context
{
    public class FlyWithUsContextFactory : IDesignTimeDbContextFactory<FlyWithUsContext>
    {
        public FlyWithUsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FlyWithUsContext>();

            optionsBuilder.UseSqlServer(ConnectionStringConfig.ConnectionString);
            return new FlyWithUsContext(optionsBuilder.Options);
        }
    }
}
