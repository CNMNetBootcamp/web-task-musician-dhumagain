using Microsoft.EntityFrameworkCore;
using Musicians.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicians.Data
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        {
        }

        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musician>().ToTable("Musician");
            modelBuilder.Entity<Album>().ToTable("Album");
            modelBuilder.Entity<Instrument>().ToTable("Instrument");
            modelBuilder.Entity<Song>().ToTable("Song");
            modelBuilder.Entity<Location>().ToTable("Location");

        }

    }
}
