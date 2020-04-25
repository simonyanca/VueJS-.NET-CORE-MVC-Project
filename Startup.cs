using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Vue_Core.Models;
namespace Vue_Core
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
            string connectionString = "Server=DESKTOP-VKNS1L5;Database=ProjectDb;Integrated Security=True";
            services.AddTransient<IMarket1Repository, Market1Repo>(provider => new Market1Repo(connectionString));
            services.AddTransient<IMarket2Repository, Market2Repo>(provider => new Market2Repo(connectionString));
            services.AddTransient<IUserRepository, UserRepo>(provider => new UserRepo(connectionString));
            services.AddTransient<ICartItemRepo, CartItemRepo>(provider => new CartItemRepo(connectionString));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options => //CookieAuthenticationOptions
                {
                   options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
               });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();     // авторизация

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}
