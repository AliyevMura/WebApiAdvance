using CarAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace CarAPI.DAL.Configrations
{
    public class ColorConfigrations : IEntityTypeConfiguration<Color>
    {
        void IEntityTypeConfiguration<Color>.Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(p => p.Name)
             .IsRequired()
             .HasColumnType(SqlDbType.VarChar.ToString());
        }
    }
}
