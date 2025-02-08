using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EfCoreConfigurations_Miftiev_.Entities;

namespace EfCoreConfigurations_Miftiev_.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Roles> Roles { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(userConfiguration =>
            {
                userConfiguration.HasKey(u => u.Id);

                userConfiguration.Property(u => u.Username).HasMaxLength(32);

                userConfiguration.HasIndex(u => u.Username).IsUnique();
            });

            modelBuilder.Entity<Roles>(roleConfiguration =>
            {
                roleConfiguration.HasKey(r => r.Id);

                roleConfiguration.Property(r => r.Title).HasMaxLength(64);

                roleConfiguration.HasIndex(r => r.Title).IsUnique();

                roleConfiguration.Property(r => r.Description).HasMaxLength(512);

            });
        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=laba6miftiev;user=root;password=1111;",
                new MySqlServerVersion(new Version(8, 0, 40))); 
        }
    }
}
