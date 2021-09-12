using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DBStore.DataAccess;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.DataAccess.Data.Repository;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.AspNetCore.Identity.UI.Services;
using DBStore.Utility;
using Microsoft.AspNetCore.Http;
using System.Net.Security;
using DBStore.DataAccess.Data.Initializer;
using DBStore.Models;
//using MailChimp.Net;
//using MailChimp.Net.Interfaces;

namespace DBStore
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>(option =>
                {
                    option.User.RequireUniqueEmail = false;
                    option.SignIn.RequireConfirmedEmail = false;

                })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();

           services.AddSingleton<IEmailSender, EmailSender>();

            services.AddScoped<IUnitOfWorkRepository, UnitOfWork>();

             services.AddScoped<IDbInitializer, DbInitializer>();
            

            services.AddSession(Options =>
            {
                Options.IdleTimeout = TimeSpan.FromMinutes(10);
                Options.Cookie.HttpOnly = true;
                Options.Cookie.IsEssential = true;
            });

            services.Configure<SMTPConfigModel>(Configuration.GetSection("SMTPConfig"));
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.ConfigureApplicationCookie(
                options =>
                {
                    options.LoginPath = new PathString("/Identity/Account/Login");
                    options.AccessDeniedPath = new PathString("/Identity/Account/AccessDenied");
                    options.LogoutPath = new PathString("/Identity/Account/Logout");
                });

            //services.AddMvc(options => options.EnableEndpointRouting = false)
            //  .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            services.AddRazorPages();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddAuthentication().AddFacebook(facebookOptions =>

            {
                facebookOptions.AppId = "3060583764052026";
                facebookOptions.AppSecret = "0567577b50b7c9a25805c328590f099f";

         
            });

            //var mailchimpManager = new MailChimpManager("cc55acd5e769a68bff16ee9cf6cbc439-us6");
            //services.AddSingleton<IMailChimpManager>(mailchimpManager);
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            dbInitializer.Initialize();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
           

            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

            //app.UseMvc();
        }
    }
}
