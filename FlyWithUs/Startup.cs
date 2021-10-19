using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Orders;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Tickets;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.ApplicationService.Services.Airplanes;
using FlyWithUs.Hosted.Service.ApplicationService.Services.Orders;
using FlyWithUs.Hosted.Service.ApplicationService.Services.Tickets;
using FlyWithUs.Hosted.Service.ApplicationService.Services.Travels;
using FlyWithUs.Hosted.Service.ApplicationService.Services.Users;
using FlyWithUs.Hosted.Service.ApplicationService.Services.World;
using FlyWithUs.Hosted.Service.Infrastructure.Common;
using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Airplanes;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Orders;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Tickets;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Travels;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.Airplanes;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.Orders;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.Tickets;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.Travels;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.Users;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.World;
using FlyWithUs.Hosted.Service.Models;
using FlyWithUs.Hosted.Service.Models.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FlyWithUs.Hosted.Service
{
    public class Startup
    {
        private readonly IConfiguration configuration;


        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddControllers().AddNewtonsoftJson();



            services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy", builder =>
                    {
                        builder
                       .WithOrigins(configuration["FlyWithUsOrigin"])
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
                    });
                });
            services.AddDbContext<FlyWithUsContext>(option => { option.UseSqlServer(configuration["ConnectionString"]); });
            services.AddScoped<IAgancyRepository, AgancyRepository>();
            services.AddScoped<IAirplaneRepository, AirplaneRepository>();
            services.AddScoped<ITravelRepository, TravelRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAirportRepository, AirportRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IOrderTicketRepository, OrderTicketRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAgancyService, AgancyService>();
            services.AddScoped<IAirplaneService, AirplaneService>();
            services.AddScoped<ITravelService, TravelService>();
            services.AddScoped<ITicektService, TicektService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAirportService, AirportService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IUserContext, UserContext>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<FlyWithUsContext>();
            configuration.GetSection("TokenConfig").Bind(new TokenConfig());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Fly With Us API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fly With Us API V1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseCors("CorsPolicy");
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}"
                  );
            });

        }
    }
}
