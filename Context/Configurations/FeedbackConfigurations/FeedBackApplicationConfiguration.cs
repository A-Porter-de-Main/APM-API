using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Database.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APMApi.Context.Configurations.FeedbackConfigurations;

internal class FeedBackApplicationConfiguration : IEntityTypeConfiguration<FeedBackApplication>
{
    public void Configure(EntityTypeBuilder<FeedBackApplication> builder)
    {
        builder
            .HasOne<User>(fa => fa.User)
            .WithMany(u => u.FeedBackApplications)
            .HasForeignKey(fa => fa.UserId)
            .HasConstraintName("FK_FeedBackApplications_Users")
            .OnDelete(DeleteBehavior.Cascade);
    }
}