using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Travels.EFCore.Models;

namespace Travels.EFCore.Context
{
    public partial class TravelContext : DbContext
    {
        public TravelContext()
        {
        }

        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Flight> Flights { get; set; } = null!;
        public virtual DbSet<Journey> Journeys { get; set; } = null!;
        public virtual DbSet<JourneyHasFlight> JourneyHasFlights { get; set; } = null!;
        public virtual DbSet<Transport> Transports { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=newShore;user=sa; password=yourStrong.Password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("flight");

                entity.Property(e => e.Id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Destination)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("destination");

                entity.Property(e => e.Origin)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("origin");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Journey>(entity =>
            {
                entity.ToTable("journey");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Destination)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("destination");

                entity.Property(e => e.Origin)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("origin");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<JourneyHasFlight>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("journey_has_flight");

                entity.Property(e => e.FlightId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("flight_id");

                entity.Property(e => e.JourneyId).HasColumnName("journey_id");

                entity.HasOne(d => d.Flight)
                    .WithMany()
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK__journey_h__fligh__3A81B327");

                entity.HasOne(d => d.Journey)
                    .WithMany()
                    .HasForeignKey(d => d.JourneyId)
                    .HasConstraintName("FK__journey_h__journ__398D8EEE");
            });

            modelBuilder.Entity<Transport>(entity =>
            {
                entity.ToTable("transport");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FlightCarrier)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("flight_carrier");

                entity.Property(e => e.FlightNumber)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("flight_number");

                entity.HasOne(d => d.FlightNumberNavigation)
                    .WithMany(p => p.Transports)
                    .HasForeignKey(d => d.FlightNumber)
                    .HasConstraintName("FK__transport__fligh__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
