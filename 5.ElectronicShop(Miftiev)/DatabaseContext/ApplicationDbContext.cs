using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicShop_Miftiev_.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElectronicShop_Miftiev_.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; } = null!;
        public DbSet<UsersEntity> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>(productsConfiguration =>
            {
                productsConfiguration.HasKey(p => p.Id);
            });

            modelBuilder.Entity<UsersEntity>(usersConfiguration =>
            {
                usersConfiguration.HasKey(p => p.Id);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=1111;database=ElectronicShopMiftievDb;",
                new MySqlServerVersion(new Version(8, 0, 40)));

        }
    }
}
