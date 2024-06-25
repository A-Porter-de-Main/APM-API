using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Database.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APMApi.Context.Configurations.FeedbackConfigurations;

internal class FeedBackConfiguration : IEntityTypeConfiguration<FeedBack>
{
    public void Configure(EntityTypeBuilder<FeedBack> builder)
    {
        builder
            .HasOne<User>(f => f.User)
            .WithMany(u => u.FeedBacks)
            .HasForeignKey(f => f.UserId)
            .HasConstraintName("FK_FeedBacks_Users")
            .OnDelete(DeleteBehavior.Cascade);
    }
}