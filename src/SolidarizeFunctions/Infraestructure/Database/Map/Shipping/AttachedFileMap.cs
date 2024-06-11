using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Solidarize.Infraestructure.Database.Map.Shipping;
public class AttachedFileMap : IEntityTypeConfiguration<Entities.Shipping.AttachedFile>
{
    public void Configure(EntityTypeBuilder<Entities.Shipping.AttachedFile> entity)
    {
        entity.ToTable("AttachedFile", "Shipping");

        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.Property(e => e.CreationDate).HasColumnType("timestamp without time zone");

        entity.Property(e => e.Type).HasColumnType("character varying");

        entity.HasOne(d => d.IdMessageDiscutionNavigation)
            .WithMany(p => p.AttachedFiles)
            .HasForeignKey(d => d.IdMessageDiscution)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("attachedfile_messagediscution_fk");
    }

}
