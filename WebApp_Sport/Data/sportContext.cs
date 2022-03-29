using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApp_Sport.Models;

#nullable disable

namespace WebApp_Sport.Data
{
    public partial class sportContext : DbContext
    {
        public sportContext()
        {
        }

        public sportContext(DbContextOptions<sportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dogadaj> Dogadajs { get; set; }
        public virtual DbSet<Pobjednik> Pobjedniks { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }
        public virtual DbSet<Utrka> Utrkas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Croatian_CI_AS");

            modelBuilder.Entity<Dogadaj>(entity =>
            {
                entity.Property(e => e.IdDogadaj).ValueGeneratedNever();

                entity.HasOne(d => d.IdPobjednikNavigation)
                    .WithMany(p => p.Dogadajs)
                    .HasForeignKey(d => d.IdPobjednik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dogadaj_Pobjednik");

                entity.HasOne(d => d.IdSportNavigation)
                    .WithMany(p => p.Dogadajs)
                    .HasForeignKey(d => d.IdSport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dogadaj_Sport");

                entity.HasOne(d => d.IdUtrkaNavigation)
                    .WithMany(p => p.Dogadajs)
                    .HasForeignKey(d => d.IdUtrka)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dogadaj_Utrka");
            });

            modelBuilder.Entity<Pobjednik>(entity =>
            {
                entity.Property(e => e.IdPobjednik).ValueGeneratedNever();

                entity.Property(e => e.Ime).IsUnicode(false);
            });

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.Property(e => e.IdSport).ValueGeneratedNever();

                entity.Property(e => e.Naziv).IsUnicode(false);
            });

            modelBuilder.Entity<Utrka>(entity =>
            {
                entity.Property(e => e.IdUtrka).ValueGeneratedNever();

                entity.Property(e => e.Naziv).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
