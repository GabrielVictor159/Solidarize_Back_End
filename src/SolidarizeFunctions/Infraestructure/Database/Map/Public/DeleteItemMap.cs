using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Solidarize.Infraestructure.Database.Map.Public;

public class DeleteItemMap : IEntityTypeConfiguration<Entities.Public.DeleteItem>
{
    public void Configure(EntityTypeBuilder<Entities.Public.DeleteItem> entity)
    {
        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.Property(e => e.CreationDate).HasColumnType("timestamp without time zone");

        entity.Property(e => e.Entity).HasColumnType("character varying");
    }

}