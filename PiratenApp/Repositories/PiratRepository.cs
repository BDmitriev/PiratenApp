using Microsoft.EntityFrameworkCore;
using PiratenApp.Data;
using PiratenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratenApp.Repositories
{
    public class PiratRepository : IPiratRepository
    {
        private ApplicationDbContext context;
        public PiratRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Pirat> Piraten => context.Piraten.Include(pirat => 
                                pirat.PiratSchiff).ThenInclude(piratSchiff => piratSchiff.Schiff);

        public void savePirat(Pirat pirat)
        {
            //context.AddRange( pirat.PiratSchiff.Select(piratSchiff => piratSchiff.Schiff) );
            //context.RemoveRange(pirat.PiratSchiff.Select(piratSchiff => piratSchiff.Schiff));

            context.Piraten.Add(pirat);
            context.SaveChanges();
        }

    }
}
