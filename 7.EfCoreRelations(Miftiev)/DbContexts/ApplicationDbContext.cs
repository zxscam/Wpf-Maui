using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCoreRelations_Miftiev_.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreRelations_Miftiev_.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<UserRoles> UserRoles { get; set; } = null!;

        public DbSet<Notes> Notes { get; set; } = null!;

        public DbSet<Permission> Permissions { get; set; } = null!;

        public DbSet<RolePermissions> RolePermissions { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(usersConfiguration =>
            {
                usersConfiguration.HasKey(p => p.Id);

                usersConfiguration.HasIndex(p => p.Login).IsUnique();
                usersConfiguration.Property(p => p.Login).HasMaxLength(32);

                usersConfiguration.HasMany(u => u.Roles).WithMany(u => u.Users).UsingEntity<UserRoles>(
                                                                                                       l => l.HasOne(ur => ur.Role).WithMany().HasForeignKey(ur => ur.RoleId),
                                                                                                       r => r.HasOne(ur => ur.User).WithMany().HasForeignKey(ur => ur.UserId));

                usersConfiguration.HasMany(n => n.Notes).WithOne(u => u.User);
            });

            modelBuilder.Entity<Role>(rolesConfiguration =>
            {
                rolesConfiguration.HasKey(p => p.Id);

                rolesConfiguration.HasIndex(p => p.Title).IsUnique();
                rolesConfiguration.Property(p => p.Title).HasMaxLength(32);

                rolesConfiguration.HasIndex(p => p.Description);
                rolesConfiguration.Property(p => p.Description).HasMaxLength(512);

                rolesConfiguration.HasMany(u => u.Users).WithMany(u => u.Roles).UsingEntity<UserRoles>(
                                                                                                        l => l.HasOne(ur => ur.User).WithMany().HasForeignKey(ur => ur.UserId),
                                                                                                        r => r.HasOne(ur => ur.Role).WithMany().HasForeignKey(ur => ur.RoleId));

                rolesConfiguration.HasMany(p => p.Permissions).WithMany(r => r.Roles).UsingEntity<RolePermissions>(
                                                                                                        l => l.HasOne(ur => ur.Permission).WithMany().HasForeignKey(ur => ur.PermissionsId),
                                                                                                        r => r.HasOne(ur => ur.Role).WithMany().HasForeignKey(ur => ur.RoleId));
            });

            modelBuilder.Entity<Notes>(notesConfiguration =>
            {
                notesConfiguration.HasKey(n => n.Id);

                notesConfiguration.HasIndex(n => n.Title).IsUnique();
                notesConfiguration.Property(n => n.Title).HasMaxLength(32);

                notesConfiguration.HasIndex(n => n.Description);
                notesConfiguration.Property(n => n.Description).HasMaxLength(512);

                notesConfiguration.HasOne(u => u.User).WithMany(n => n.Notes).HasForeignKey(u => u.UserId);
            });

            modelBuilder.Entity<Permission>(permissionConfiguration =>
            {
                permissionConfiguration.HasKey(p => p.Id);

                permissionConfiguration.HasIndex(p => p.Title).IsUnique();
                permissionConfiguration.Property(p => p.Title).HasMaxLength(32);

                permissionConfiguration.HasIndex(p => p.Description);
                permissionConfiguration.Property(p => p.Description).HasMaxLength(512);

                permissionConfiguration.HasMany(r => r.Roles).WithMany(p => p.Permissions).UsingEntity<RolePermissions>(
                                                                                                        l => l.HasOne(ur => ur.Role).WithMany().HasForeignKey(ur => ur.RoleId),
                                                                                                        r => r.HasOne(ur => ur.Permission).WithMany().HasForeignKey(ur => ur.PermissionsId));
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=laba7miftiev;user=root;password=1111;",
                new MySqlServerVersion(new Version(8, 0, 40)));

        }
    }
}
