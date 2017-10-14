using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ShipBobUserOrderManagement.Services.Infrastructures;
using ShipBobUserOrderManagement.Services.Repository;

namespace ShipBobUserOrderManagement
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
            //Dependency Injection for SQL Connection
            services.AddDbContext<Models.AppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("databaseconnection")));
            services.AddMvc();
            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<IOrder, OrderRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //Admin Area Route
                routes.MapRoute(
                    name: "AdminAreaRoute",
                    template: "{area=exists}/{controller=Users}/{action=Index}/{id=UrlParameter.Optional}");
            });
        }
    }
}
