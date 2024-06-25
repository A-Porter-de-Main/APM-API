using APMApi.Models.Database.RequestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APMApi.Context.Configurations.RequestConfigurations;

internal class ResponseConfiguration : IEntityTypeConfiguration<Response>
{
    public void Configure(EntityTypeBuilder<Response> builder)
    {
        builder
            .HasOne(r => r.Request)
            .WithMany()
            .HasForeignKey(r => r.RequestId)
            .HasConstraintName("FK_Responses_Requests");
        
        builder
            .HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .HasConstraintName("FK_Responses_Users");

        builder
            .HasOne(r => r.Status)
            .WithMany(rs => rs.Responses)
            .HasForeignKey(r => r.StatusId)
            .HasConstraintName("FK_Responses_Statuses");
    }
}