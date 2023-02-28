using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MagyarorszagVarosai.Models
{
    public partial class magyar_telepulesekContext : DbContext
    {
        public magyar_telepulesekContext()
        {
        }

        public magyar_telepulesekContext(DbContextOptions<magyar_telepulesekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Jogallas> Jogallas { get; set; }
        public virtual DbSet<Megyek> Megyek { get; set; }
        public virtual DbSet<Telepulesek> Telepulesek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;database=magyar_telepulesek;user=root", x => x.ServerVersion("10.4.27-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogallas>(entity =>
            {
                entity.HasKey(e => e.Suly)
                    .HasName("PRIMARY");

                entity.ToTable("jogallas");

                entity.Property(e => e.Suly)
                    .HasColumnName("suly")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Jogallas1)
                    .IsRequired()
                    .HasColumnName("jogallas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Megyek>(entity =>
            {
                entity.HasKey(e => e.Kod)
                    .HasName("PRIMARY");

                entity.ToTable("megyek");

                entity.Property(e => e.Kod)
                    .HasColumnName("kod")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasColumnName("nev")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Telepulesek>(entity =>
            {
                entity.ToTable("telepulesek");

                entity.HasIndex(e => e.Jogallas)
                    .HasName("FK_telepulesek_jogallas");

                entity.HasIndex(e => e.Megyekod)
                    .HasName("FK_telepulesek_megyekod");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Irszam)
                    .HasColumnName("irszam")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Jogallas)
                    .HasColumnName("jogallas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Kshkod)
                    .IsRequired()
                    .HasColumnName("kshkod")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Lakasok)
                    .HasColumnName("lakasok")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Long).HasColumnName("long");

                entity.Property(e => e.Megyekod)
                    .IsRequired()
                    .HasColumnName("megyekod")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Nepesseg)
                    .HasColumnName("nepesseg")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasColumnName("nev")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Terulet)
                    .HasColumnName("terulet")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.JogallasNavigation)
                    .WithMany(p => p.Telepulesek)
                    .HasForeignKey(d => d.Jogallas)
                    .HasConstraintName("FK_telepulesek_jogallas");

                entity.HasOne(d => d.MegyekodNavigation)
                    .WithMany(p => p.Telepulesek)
                    .HasForeignKey(d => d.Megyekod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_telepulesek_megyekod");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
