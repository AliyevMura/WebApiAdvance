using CarAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace CarAPI.DAL.Configrations
{
    public class CarConfigrations : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(c => c.ModelYear)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType(SqlDbType.Int.ToString());


            builder.Property(c => c.DailyPrice)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType(SqlDbType.Int.ToString());

            builder.Property(c=>c.Description)
                .IsRequired()
                .HasDefaultValue("DDDDD")
                .HasColumnType(SqlDbType.NVarChar.ToString())
                ;
        }
    }
}
