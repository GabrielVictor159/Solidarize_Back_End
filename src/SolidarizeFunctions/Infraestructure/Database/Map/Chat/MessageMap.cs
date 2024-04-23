
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solidarize.Infraestructure.Database.Entities.Chat;

namespace Solidarize.Infraestructure.Database.Map.Chat;

public class MessageMap: IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Messages", "Chat");
        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.CreationDate).HasColumnType("timestamp without time zone");
        builder.Property(e => e.DataType).IsRequired().HasColumnType("character varying");
        builder.Property(e => e.MessageBody).IsRequired();
        builder.Property(e => e.SeenUsers).IsRequired();
        builder.HasOne(d => d.Chat)
            .WithMany(p => p.Messages)
            .HasForeignKey(d => d.IdChat)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("messages_chat_fk");
        builder.HasOne(d => d.Company)
            .WithMany()
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("messages_company_fk");
    }
}

