using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            services.AddMvc(e=> e.EnableEndpointRouting=false);
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            //app.UseMvc(route=>
            //{
            //    route.MapRoute("default", "{controller}/{action}/{id?}");
            //});
            app.UseMvcWithDefaultRoute();
            
        }
    }
}
