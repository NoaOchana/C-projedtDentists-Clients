using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dal.Models
{
    public partial class manageDB : DbContext
    {
        public manageDB()
        {
        }

        public manageDB(DbContextOptions<manageDB> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Dentist> Dentists { get; set; } = null!;
        public virtual DbSet<Queue> Queues { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\c#\\project\\project\\dal\\DentistClinic.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.ClientName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hmo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HMO");
            });

            modelBuilder.Entity<Dentist>(entity =>
            {
                entity.Property(e => e.DentistId)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.DentistName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Queue>(entity =>
            {
                entity.ToTable("Queue");

                entity.Property(e => e.QueueId)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.ClientId)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.DentistId)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.QueueDate).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Queues)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Queue_ToTable");

                entity.HasOne(d => d.Dentist)
                    .WithMany(p => p.Queues)
                    .HasForeignKey(d => d.DentistId)
                    .HasConstraintName("FK_Queue_ToTable_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
