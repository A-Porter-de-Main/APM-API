using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Database.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APMApi.Context.Configurations.FeedbackConfigurations;

internal class IssueConfiguration : IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder
            .HasOne<User>(i => i.User)
            .WithMany(u => u.Issues)
            .HasForeignKey(fa => fa.UserId)
            .HasConstraintName("FK_Issues_Users")
            .OnDelete(DeleteBehavior.Cascade);
    }
}