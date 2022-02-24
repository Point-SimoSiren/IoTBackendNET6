using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IoTBackendNET6.Models
{
    public partial class iotdataContext : DbContext
    {
        public iotdataContext()
        {
        }

        public iotdataContext(DbContextOptions<iotdataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Measurement> Measurements { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=duuniserver.database.windows.net;Database=iotdata;User ID=sirensimo;Password=Fullstack7777!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.Property(e => e.MeasurementId).HasColumnName("measurement_id");

                entity.Property(e => e.DeviceId).HasColumnName("device_id");

                entity.Property(e => e.Humidity)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("humidity");

                entity.Property(e => e.Optional)
                    .HasMaxLength(20)
                    .HasColumnName("optional");

                entity.Property(e => e.Pressure)
                    .HasColumnType("decimal(6, 2)")
                    .HasColumnName("pressure");

                entity.Property(e => e.Temperature)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("temperature");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("time");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
