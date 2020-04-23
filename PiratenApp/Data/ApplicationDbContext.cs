
using Microsoft.EntityFrameworkCore;
using PiratenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratenApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<Pirat> Piraten { get; set; }
        public DbSet<Schiff> Schiffe { get; set; }

        public DbSet<PiratSchiff> PiratSchiffe { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            modelBuilder.Entity<PiratSchiff>().HasKey(piratSchiff => new { piratSchiff.PSID });


            modelBuilder.Entity<PiratSchiff>()
                        .HasOne(piratSchiff => piratSchiff.Pirat)
                        .WithMany(pirat => pirat.PiratSchiff)
                        .HasForeignKey(piratSchiff => piratSchiff.PiratId);


            modelBuilder.Entity<PiratSchiff>()
                        .HasOne(piratSchiff => piratSchiff.Schiff)
                        .WithMany(schiff => schiff.PiratSchiff)
                        .HasForeignKey(piratSchiff => piratSchiff.SchiffId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
