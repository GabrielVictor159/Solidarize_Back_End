using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solidarize.Infraestructure.Database.Entities.Shipping;

namespace Solidarize.Infraestructure.Database.Map.Shipping;
public class MessageDiscutionMap : IEntityTypeConfiguration<Entities.Shipping.MessageDiscution>
{
    public void Configure(EntityTypeBuilder<Entities.Shipping.MessageDiscution> entity)
    {
        entity.ToTable("MessageDiscution", "Shipping");

        entity.HasIndex(e => e.IdShipping, "messagediscution_unique")
            .IsUnique();

        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.HasOne(d => d.IdShippingNavigation)
            .WithMany(p => p.MessageDiscution)
            .HasForeignKey(d => d.IdShipping)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("messagediscution_shipping_fk");

        entity.HasOne(d => d.IdUserNavigation)
            .WithMany(p => p.MessageDiscutions)
            .HasForeignKey(d => d.IdUser)
            .HasConstraintName("messagediscution_company_fk");
    }

}