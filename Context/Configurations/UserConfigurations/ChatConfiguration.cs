using APMApi.Models.Database.RequestModels;
using APMApi.Models.Database.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APMApi.Context.Configurations.UserConfigurations;

internal class ChatConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder
            .HasOne<Response>(c => c.Response)
            .WithOne(r => r.Chat)
            .HasForeignKey<Chat>(c => c.ResponseId)
            .HasConstraintName("FK_Chats_Responses")
            .OnDelete(DeleteBehavior.SetNull);
    }
}
        