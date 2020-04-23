using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PiratenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratenApp.Data
{
    public class SeedData
    {

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if (!context.Schiffe.Any())
            {
                context.Schiffe.AddRange(

                    new Schiff
                    {
                        SchiffName = "Albatross"
                    },
                    new Schiff
                    {
                        SchiffName = "Aurora"
                    },
                    new Schiff
                    {
                        SchiffName = "Avalon"
                    },
                    new Schiff
                    {
                        SchiffName = "Leona"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
