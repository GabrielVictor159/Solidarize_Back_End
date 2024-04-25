using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solidarize.Infraestructure.Database.Entities.Users;

namespace Solidarize.Infraestructure.Database.Map.Users;

public class RequestCompanyMap : IEntityTypeConfiguration<RequestCompany>
{
    public void Configure(EntityTypeBuilder<RequestCompany> entity)
    {

        entity.ToTable("RequestCompany", "Users");

        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.Property(e => e.Body).IsRequired(true);

        entity.Property(e => e.CreationDate).HasColumnType("timestamp without time zone");

    }
}
