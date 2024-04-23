
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solidarize.Infraestructure.Database.Entities.Users;

namespace Solidarize.Infraestructure.Database.Map.Users;

public class PasswordMap : IEntityTypeConfiguration<Password>
{
    public void Configure(EntityTypeBuilder<Password> builder)
    {
        builder.ToTable("Password", "Users");
        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.Encryption).HasColumnType("character varying");
        builder.Property(e => e.LastDateModified).HasColumnType("timestamp without time zone");
        builder.Property(e => e.PasswordValue).IsRequired().HasColumnType("character varying");
    }
}

