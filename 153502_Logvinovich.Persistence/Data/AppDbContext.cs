using _153502_Logvinovich.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Logvinovich.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Superhero>().HasKey(e => e.Id);
            modelBuilder.Entity<SuperheroSkills>().HasKey(t => t.Id);

            modelBuilder.Entity<SuperheroSkills>().HasOne(p => p.Superhero).WithMany(t => t.Skills).HasForeignKey(p => p.SuperheroId);

            modelBuilder.Entity<SuperheroSkills>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Superhero>().Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}