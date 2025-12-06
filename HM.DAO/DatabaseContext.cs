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
                optionsBuilder.UseMySql(connectionString, mySqlOptions => mySqlOptions.ServerVersion(ServerVersion.AutoDetect(connectionString)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ActionDTO>().Property(S => S.);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}