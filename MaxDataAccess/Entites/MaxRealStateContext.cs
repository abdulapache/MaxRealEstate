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

        public virtual DbSet<AdminUser> AdminUsers { get; set; } = null!;
        public virtual DbSet<Agent> Agents { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<ContactU> ContactUs { get; set; } = null!;
        public virtual DbSet<Property> Properties { get; set; } = null!;
        public virtual DbSet<UserQuery> UserQueries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ec2-18-189-230-198.us-east-2.compute.amazonaws.com,1433;Database=MaxRealState;User Id= dev_gofinance; Password=mV#opiN!!; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.HasIndex(e => e.AgentId, "UQ__AdminUse__9AC3BFF030F2BDD8")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__AdminUse__A9D1053428ABA54B")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.PasswordHash).HasMaxLength(500);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Admin')");
            });

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

            modelBuilder.Entity<ContactU>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.Message).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Subject).HasMaxLength(500);
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

            modelBuilder.Entity<UserQuery>(entity =>
            {
                entity.ToTable("UserQuery");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.Mobile).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Property).HasMaxLength(50);

                entity.Property(e => e.Purpose).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
