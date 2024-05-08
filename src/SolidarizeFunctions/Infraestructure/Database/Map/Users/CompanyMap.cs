
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solidarize.Infraestructure.Database.Entities.Users;

namespace Solidarize.Infraestructure.Database.Map.Users;

public class CompanyMap : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Company", "Users");
        builder.HasIndex(e => e.Email).IsUnique(true);
        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.Address).IsRequired().HasColumnType("character varying");
        builder.Property(e => e.BanDate).HasColumnType("timestamp without time zone");
        builder.Property(e => e.Cnpj).IsRequired().HasColumnType("character varying").HasColumnName("CNPJ");
        builder.Property(e => e.CompanyName).IsRequired().HasColumnType("character varying");
        builder.Property(e => e.CreationDate).HasColumnType("timestamp without time zone");
        builder.Property(e => e.Email).IsRequired().HasColumnType("character varying");
        builder.Property(e => e.Idpassword).HasColumnName("idpassword");
        builder.Property(e => e.LastAccessDate).HasColumnType("timestamp without time zone");
        builder.Property(e => e.LocationX).IsRequired().HasColumnType("character varying");
        builder.Property(e => e.LocationY).IsRequired().HasColumnType("character varying");
        builder.Property(e => e.Telefone).IsRequired().HasColumnType("character varying");
        builder.Property(e => e.LegalNature).HasColumnType("character varying");
        builder.HasOne(d => d.Password)
            .WithMany(p => p.Companies)
            .HasForeignKey(d => d.Idpassword)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("company_fk");
    }
}

