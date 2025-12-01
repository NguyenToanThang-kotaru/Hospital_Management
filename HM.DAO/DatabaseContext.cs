using System.Data.Entity;
using HM.DTO;

namespace HM.DAO
{
    internal class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("HospitalConnectionString")
        {
        }
        public DbSet<ActionDTO> HanhDongs { get; set; }
        public DbSet<FunctionDTO> ChucNangs { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionDTO>().ToTable("chucnang");
            modelBuilder.Entity<ActionDTO>().ToTable("hanhdong");

            base.OnModelCreating(modelBuilder);
        }
    }
}