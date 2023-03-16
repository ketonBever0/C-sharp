using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_tema.Models
{
    public class IngatlanContext : DbContext
    {
        public DbSet<IngatlanModel> Ingatlanok { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=ingatlan;user=root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KategoriakModel>().HasIndex(k => k.Nev).IsUnique();
            modelBuilder.Entity<KategoriakModel>().HasData(
                new KategoriakModel { Id = 1, Nev = "Ház" },
                new KategoriakModel { Id = 2, Nev = "Lakás" },
                new KategoriakModel { Id = 3, Nev = "Építési telek" },
                new KategoriakModel { Id = 4, Nev = "Garázs" },
                new KategoriakModel { Id = 5, Nev = "Mezőgazdasági terület" },
                new KategoriakModel { Id = 6, Nev = "Ipari ingatlan" }
                );
        }

    }
}
