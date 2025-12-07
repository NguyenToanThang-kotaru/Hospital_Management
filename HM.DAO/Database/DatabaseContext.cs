using HM.DAO.LINQ;
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
        public DbSet<RoleDTO> VaiTros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "server=localhost;port=3306;database=hospital;uid=root;password=;";
                optionsBuilder.UseMySql(connectionString, mySqlOptions => mySqlOptions.ServerVersion(ServerVersion.AutoDetect(connectionString)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình cho ActionDTO (HanhDong)
            modelBuilder.Entity<ActionDTO>(entity =>
            {
                entity.ToTable("hanhdong");

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

                entity.HasIndex(e => e.MaCN)
                    .IsUnique()
                    .HasName("IX_ChucNang_MaCN");
            });

            // Cấu hình cho RoleDTO (VaiTro) - THÊM MỚI
            modelBuilder.Entity<RoleDTO>(entity =>
            {
                entity.ToTable("vaitro"); 

                entity.HasKey(e => e.MaVT); 

                entity.Property(e => e.MaVT)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MaVT");

                entity.Property(e => e.TenVT)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenVT");

                entity.Property(e => e.TrangThaiXoa)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("TrangThaiXoa")
                    .HasDefaultValue("0") 
                    .HasConversion(
                        v => v.ToString(),          
                        v => v.ToString()          
                    );

                // Tạo index cho mã vai trò
                entity.HasIndex(e => e.MaVT)
                    .IsUnique()
                    .HasName("IX_VaiTro_MaVT");

                // Tạo index cho tên vai trò (nếu cần tìm kiếm theo tên)
                entity.HasIndex(e => e.TenVT)
                    .HasName("IX_VaiTro_TenVT");

                // Có thể thêm check constraint cho TrangThaiXoa
                // entity.HasCheckConstraint("CK_VaiTro_TrangThaiXoa", "TrangThaiXoa IN ('0', '1')");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}