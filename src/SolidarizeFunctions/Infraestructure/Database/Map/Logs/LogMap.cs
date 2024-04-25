using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solidarize.Infraestructure.Database.Entities;

namespace Solidarize.Infraestructure.Database.Map.Logs;

public class LogMap : IEntityTypeConfiguration<Entities.Logs.Log>
{
    public void Configure(EntityTypeBuilder<Entities.Logs.Log> entity)
    {
        entity.ToTable("SolidarizeLog", "Logs");
        entity.Property(e => e.Id).ValueGeneratedNever();
        entity.Property(e => e.LogDate).HasColumnType("timestamp without time zone");
        entity.Property(e => e.Message).HasColumnType("character varying");
    }

}
