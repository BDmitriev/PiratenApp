using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PiratenApp.Data;
using PiratenApp.Repositories;

namespace PiratenApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration) => Configuration = configuration;



        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<IPiratRepository, PiratRepository>();
            services.AddTransient<ISchiffRepository, SchiffRepository>();
            services.AddTransient<IPiratSchiffRepository, PiratSchiffRepository>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                                        Configuration["PiratenApp:ConnectionString"]
                                    )
                );


            services.AddMvc(option => option.EnableEndpointRouting = false);
           
        }


        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseStatusCodePages();

            app.UseStaticFiles();


            app.UseMvc(routes => {

                routes.MapRoute(
                    name: null,
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Pirat", action = "Index", productPage = 1 }
                );

            });


             SeedData.EnsurePopulated(app);
        }
    }
}
