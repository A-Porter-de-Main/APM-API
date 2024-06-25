using APMApi.Models.Database.RequestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APMApi.Context.Configurations.RequestConfigurations;

internal class ResponseStatusConfiguration : IEntityTypeConfiguration<ResponseStatus>
{
    public void Configure(EntityTypeBuilder<ResponseStatus> builder)
    {
        builder
            .HasMany<Response>(s => s.Responses)
            .WithOne(rs => rs.Status)
            .HasForeignKey(r => r.StatusId)
            .HasConstraintName("FK_Responses_Statuses")
            .OnDelete(DeleteBehavior.SetNull);
    }
}