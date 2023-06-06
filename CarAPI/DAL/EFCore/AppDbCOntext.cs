using CarAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace CarAPI.DAL.EFCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Car>().Property(c => c.ModelYear)
            //    .IsRequired()
            //    .HasColumnType(SqlDbType.Int.ToString())
            //    .HasDefaultValue(0)
            //    ;


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }

    }
}
