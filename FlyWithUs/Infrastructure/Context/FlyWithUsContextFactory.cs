using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FlyWithUs.Hosted.Service.Infrastructure.Context
{
    public class FlyWithUsContextFactory : IDesignTimeDbContextFactory<FlyWithUsContext>
    {
        public FlyWithUsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FlyWithUsContext>();

            optionsBuilder.UseSqlServer("Data Source =LAPTOP-VIV37RCJ\\SQL2019;Initial Catalog=FlyWithUsDB;Integrated Security=true");
            return new FlyWithUsContext(optionsBuilder.Options);
        }
    }
}
