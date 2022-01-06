using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorialASPNETCore.Context;
using TutorialASPNETCore.Models;
using TutorialASPNETCore.Repositories;

namespace TutorialASPNETCore
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<TutorialContext>(options => options.UseSqlServer(_config.GetConnectionString("NET")));
            services.AddMvc(e=>
            {
                e.EnableEndpointRouting = false;
                var policy=new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                e.Filters.Add(new AuthorizeFilter(policy));
             

                
            });
            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "1076546333611-7ofam5sc9kbs70s5rlgqtujujr9f6alr.apps.googleusercontent.com";
                options.ClientSecret = "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";
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Administration/AccessDenied");
            });
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddAuthorization(options=>
            {
               
            });
            
            services.AddIdentity<ApplicationUser, IdentityRole>(e=>
            {
                e.Password.RequiredLength = 1;
                e.Password.RequiredUniqueChars = 0;
                e.Password.RequireLowercase = false;
                e.Password.RequireUppercase = false;
                e.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<TutorialContext>();
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.AccessDeniedPath = "/login";
            //    options.LoginPath = "/login";
            //    options.LogoutPath = "/logout";
            //});


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
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            //app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
         
            //app.UseMvc(route=>
            //{
            //    route.MapRoute("default", "{controller}/{action}/{id?}");
            //});
            app.UseMvcWithDefaultRoute();
            
        }
    }
}
