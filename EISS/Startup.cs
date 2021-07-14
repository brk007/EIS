using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EIS.Context;
using EIS.CustomValidator;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EISS
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EISContext>();
            services.AddIdentity<AppUser, AppRole>(opt=> {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;  
                opt.Password.RequiredLength = 2;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
                opt.Lockout.MaxFailedAccessAttempts = 4;
            }).AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<EISContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Login/Index");
                opt.Cookie.HttpOnly = true;
                opt.Cookie.Name = "Cookie";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
            });

            services.AddControllersWithViews();
            services.AddMvc(options => { options.EnableEndpointRouting = false;});
            services.AddOptions();
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

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }   
    }
}
