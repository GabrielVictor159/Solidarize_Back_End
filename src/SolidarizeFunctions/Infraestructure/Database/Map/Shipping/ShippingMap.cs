using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Solidarize.Infraestructure.Database.Map.Shipping;

public class ShippingMap : IEntityTypeConfiguration<Entities.Shipping.Shipping>
{
    public void Configure(EntityTypeBuilder<Entities.Shipping.Shipping> entity)
    {
        entity.ToTable("Shipping", "Shipping");

        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.Property(e => e.CreationDate).HasColumnType("timestamp without time zone");

        entity.Property(e => e.Name).HasColumnType("character varying");

        entity.HasOne(d => d.IdUserCreationNavigation)
            .WithMany(p => p.ShippingIdUserCreationNavigations)
            .HasForeignKey(d => d.IdUserCreation)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("shipping_company_fk");

        entity.HasOne(d => d.IdUserResponseNavigation)
            .WithMany(p => p.ShippingIdUserResponseNavigations)
            .HasForeignKey(d => d.IdUserResponse)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("shipping_company_fk_1");
    }

}
