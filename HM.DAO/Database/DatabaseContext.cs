using HM.DTO;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;

namespace HM.DAO
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ActionDTO> HanhDongs { get; set; }
        public DbSet<FunctionDTO> ChucNangs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "server=localhost;port=3306;database=hospital;uid=root;password=;";
                optionsBuilder.UseMySql(connectionString,
                    mySqlOptions => mySqlOptions.ServerVersion(ServerVersion.AutoDetect(connectionString)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình cho ActionDTO (HanhDong)
            modelBuilder.Entity<ActionDTO>(entity =>
            {
                entity.ToTable("hanhdong"); // Tên bảng tiếng Việt

                entity.HasKey(e => e.MaHD); 

                entity.Property(e => e.MaHD)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MaHD");

                entity.Property(e => e.TenHD)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenHD");

                entity.HasIndex(e => e.MaHD)
                    .IsUnique()
                    .HasName("IX_HanhDong_MaHD");
            });

            // Cấu hình cho FunctionDTO (ChucNang)
            modelBuilder.Entity<FunctionDTO>(entity =>
            {
                entity.ToTable("chucnang"); 

                entity.HasKey(e => e.MaCN); 

                entity.Property(e => e.MaCN)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MaCN");

                entity.Property(e => e.TenCN)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenCN");

                // Tạo index cho mã
                entity.HasIndex(e => e.MaCN)
                    .IsUnique()
                    .HasName("IX_ChucNang_MaCN");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}