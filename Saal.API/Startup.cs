using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Saal.API.Data;
using Saal.API.Repository;
using Saal.API.Services.Interfaces;
using Saal.API.Services;
using Saal.API.Controllers.Mvc;

namespace Saal.API
{
    public class Startup
    {
        /// <summary>
        /// Initialization of startup class.
        /// </summary>
        /// <param name="configuration">Configuration instance.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration property.
        /// </summary>
        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(Configuration["ApiSettings:BaseUrl"])
            });

            services.AddControllers();
            services.AddControllersWithViews();

            services.AddDbContext<SaalContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SaalContext"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Saal Test Application", Description = "Code test - Pablo Tejedor.", Version = "v1" });

            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IRestaurantService), typeof(RestaurantService));
            services.AddScoped(typeof(ICityService), typeof(CityService));
            services.AddAutoMapper(typeof(MappingProfile));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Saal Test");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                        name: "create",
                        pattern: "{controller=Home}/{action=Create}");
            });

        }
    }
}
