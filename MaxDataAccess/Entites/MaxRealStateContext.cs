using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MaxDataAccess.Entites
{
    public partial class MaxRealStateContext : DbContext
    {
        public MaxRealStateContext()
        {
        }

        public MaxRealStateContext(DbContextOptions<MaxRealStateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agents { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Property> Properties { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=AR\\ARRAHMAN;Database=MaxRealState;User Id= sa; Password=Sql123@; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Profile).HasMaxLength(255);
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedUser).HasMaxLength(255);

                entity.Property(e => e.PictureOne).HasMaxLength(255);

                entity.Property(e => e.PictureTwo).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Area).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.CommercialType).HasMaxLength(255);

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.OwnerAddress).HasMaxLength(500);

                entity.Property(e => e.OwnerName).HasMaxLength(255);

                entity.Property(e => e.OwnerPhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Pic1).HasMaxLength(255);

                entity.Property(e => e.Pic2).HasMaxLength(255);

                entity.Property(e => e.Pic3).HasMaxLength(255);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.PropertyName).HasMaxLength(255);

                entity.Property(e => e.PropertyType).HasMaxLength(255);

                entity.Property(e => e.Purpose).HasMaxLength(255);

                entity.Property(e => e.ResidentType).HasMaxLength(255);

                entity.Property(e => e.SqFt).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
