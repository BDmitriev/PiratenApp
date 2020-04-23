using Microsoft.EntityFrameworkCore;
using PiratenApp.Data;
using PiratenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratenApp.Repositories
{
    public class PiratSchiffRepository : IPiratSchiffRepository
    {
        private ApplicationDbContext context;
        public PiratSchiffRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<PiratSchiff> PiratSchiffe => context.PiratSchiffe
                                                        .Include(piratSchiff => piratSchiff.Pirat)
                                                        .Include(piratSchiff => piratSchiff.Schiff);

        public void savePiratSchiff(PiratSchiff piratSchiff)
        {
            context.PiratSchiffe.Add(piratSchiff);
            context.SaveChanges();
        }
    }
}
