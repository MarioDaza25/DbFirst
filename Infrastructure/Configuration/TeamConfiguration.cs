
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

class TeamConfiguration:IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("team");

        builder.HasIndex(e => e.Name, "idx_team_name").IsUnique();

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");
        
        builder
            .HasMany(p => p.Drivers)
            .WithMany(p => p.Teams)
            .UsingEntity<DriverTeam>(

                j => j
                .HasOne(pt => pt.Driver)
                .WithMany(p => p.DriverTeam)
                .HasForeignKey(pt => pt.IdDriverFk),

                j => j 
                    .HasOne(pt => pt.Team)
                    .WithMany(t => t.DriverTeam)
                    .HasForeignKey(pt => pt.IdTeamFk),


                j => j.HasKey(t => new{t.IdDriverFk, t.IdTeamFk})                
            );
    }
}
            