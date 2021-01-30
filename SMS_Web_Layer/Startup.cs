using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SMS_Data_Layer.ProjectContext;
using SMS_Data_Layer.Repositories.Concrete.EntityTypeRepositories;
using SMS_Data_Layer.Repositories.Interfaces.IEntityTypeRepositories;
using SMS_Entity_Layer.Entities.Concrete;

namespace SMS_Web_Layer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromDays(30);
                //opt.IdleTimeout = TimeSpan.FromSeconds(10);
            });
            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 3;
            })
           .AddEntityFrameworkStores<ApplicationDbContext>()
           .AddDefaultTokenProviders();




            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "page",
                    "{slug?}",
                    defaults: new { controller = "Page", action = "Page" });

             
                endpoints.MapControllerRoute(
                   "student",
                   "student/{lessonSlug}",
                   defaults: new { controller = "Student", action = "StudentByLessons" });
           

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
