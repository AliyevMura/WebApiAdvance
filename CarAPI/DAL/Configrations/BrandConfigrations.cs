using CarAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace CarAPI.DAL.Configrations
{
    public class BrandConfigrations : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(b => b.Name)
               .IsRequired()
               .HasColumnType(SqlDbType.NText.ToString());
        }
    }
}
