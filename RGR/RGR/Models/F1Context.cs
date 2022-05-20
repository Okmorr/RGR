using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RGR
{
    public partial class F1Context : DbContext
    {
        public F1Context()
        {
        }

        public F1Context(DbContextOptions<F1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Championship> Championships { get; set; } = null!;
        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<ResultDriver> ResultDrivers { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<Track> Tracks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                    optionsBuilder.UseSqlite("Data Source=C:\\Users\\Us1\\Desktop\\SQLite\\BS\\F1.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Championship>(entity =>
            {
                entity.HasKey(e => e.YearId);

                entity.ToTable("Championship");

                entity.Property(e => e.YearId)
                    .ValueGeneratedNever()
                    .HasColumnName("YearID");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(e => e.NumId);

                entity.ToTable("Driver");

                entity.Property(e => e.NumId)
                    .ValueGeneratedNever()
                    .HasColumnName("NumID");

                entity.Property(e => e.Name).HasColumnType("STRING");

                entity.HasOne(d => d.NameNavigation)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.Name);
            });

            modelBuilder.Entity<ResultDriver>(entity =>
            {
                entity.HasKey(e => e.PosId);

                entity.ToTable("Result driver");

                entity.Property(e => e.PosId)
                    .HasColumnType("STRING")
                    .HasColumnName("PosID");

                entity.Property(e => e.Best).HasColumnType("DOUBLE");

                entity.Property(e => e.Interval).HasColumnType("DOUBLE");

                entity.Property(e => e.KpH)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("KP H");

                entity.Property(e => e.NameTrack)
                    .HasColumnType("STRING")
                    .HasColumnName("Name track");

                entity.Property(e => e.NumDriver).HasColumnName("Num driver");

                entity.Property(e => e.Time).HasColumnType("DOUBLE");

                entity.HasOne(d => d.NameTrackNavigation)
                    .WithMany(p => p.ResultDrivers)
                    .HasForeignKey(d => d.NameTrack);

                entity.HasOne(d => d.NumDriverNavigation)
                    .WithMany(p => p.ResultDrivers)
                    .HasForeignKey(d => d.NumDriver);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.NameId);

                entity.ToTable("Team");

                entity.Property(e => e.NameId)
                    .HasColumnType("STRING")
                    .HasColumnName("NameID");

                entity.Property(e => e.TrackName)
                    .HasColumnType("STRING")
                    .HasColumnName("Track name");

                entity.HasOne(d => d.TrackNameNavigation)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.TrackName);
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasKey(e => e.NameId);

                entity.ToTable("Track");

                entity.Property(e => e.NameId)
                    .HasColumnType("STRING")
                    .HasColumnName("NameID");

                entity.HasOne(d => d.YearNavigation)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.Year);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
