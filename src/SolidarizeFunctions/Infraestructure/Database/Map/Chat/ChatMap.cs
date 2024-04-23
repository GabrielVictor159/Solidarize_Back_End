

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Solidarize.Infraestructure.Database.Map.Chat;
public class ChatMap : IEntityTypeConfiguration<Entities.Chat.Chat>
{
    public void Configure(EntityTypeBuilder<Entities.Chat.Chat> builder)
    {
        builder.ToTable("Chat", "Chat");
        builder.HasIndex(e => e.Users).IsUnique(true);
        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.CreationDate).HasColumnType("timestamp without time zone");
        builder.Property(e => e.Users).IsRequired();
    }
}

