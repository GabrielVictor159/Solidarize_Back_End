using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solidarize.Infraestructure.Database.Entities.Users;

namespace Solidarize.Infraestructure.Database.Map.Users;

public class RequestRecoverPasswordMap: IEntityTypeConfiguration<RequestRecoverPassword>
{
    public void Configure(EntityTypeBuilder<RequestRecoverPassword> entity)
    {
        entity.ToTable("RequestRecoverPassword", "Users");

        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.Property(e => e.CreationDate).HasColumnType("timestamp without time zone");
    }
    
}
