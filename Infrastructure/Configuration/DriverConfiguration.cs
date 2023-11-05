
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

class DriverConfiguration:IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("driver");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Age).HasColumnName("age");
        builder.Property(e => e.Idteam).HasColumnName("idteam");
        builder.Property(e => e.Name)
            .HasMaxLength(60)
            .HasColumnName("name");

    }
}
            