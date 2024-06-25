using APMApi.Models.Database.RequestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APMApi.Context.Configurations.RequestConfigurations;

internal class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        // Status
        builder
            .HasOne(r => r.Status)
            .WithMany()
            .HasForeignKey(r => r.StatusId);

        // Pictures
        builder
            .HasMany(r => r.Pictures)
            .WithMany(p => p.Requests)
            .UsingEntity(j => j.ToTable("RequestPictures"));

        // Responses
        builder
            .HasMany(r => r.Responses)
            .WithOne(r => r.Request)
            .HasForeignKey(r => r.RequestId);

        // Skills
        builder
            .HasMany(r => r.Skills)
            .WithMany(s => s.Requests)
            .UsingEntity(j => j.ToTable("RequestSkills"));

        // Objects
        builder
            .HasMany(r => r.Objects)
            .WithMany(o => o.Requests)
            .UsingEntity(j => j.ToTable("RequestObjects"));
    }
}