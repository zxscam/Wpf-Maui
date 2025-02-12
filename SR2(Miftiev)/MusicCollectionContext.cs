using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SR2_Miftiev_
{
    public class MusicCollectionContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "musiccollection.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

        class Program
        {
            static void Main(string[] args)
            {
                using (var context = new MusicCollectionContext())
                {
                    context.Database.EnsureCreated(); // Создание базы данных
                }

                Console.WriteLine("База данных создана или уже существует.");
            }
        }
    }
}
