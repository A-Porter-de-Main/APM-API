using APMApi.Models.Database.RequestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APMApi.Context.Configurations.RequestConfigurations;

internal class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder
            .HasMany<Request>(s => s.Requests)
            .WithOne(r => r.Status)
            .HasForeignKey(r => r.StatusId)
            .HasConstraintName("FK_Requests_Statuses")
            .OnDelete(DeleteBehavior.SetNull);
    }
}