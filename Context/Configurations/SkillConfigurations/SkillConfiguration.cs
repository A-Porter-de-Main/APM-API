using APMApi.Models.Database;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Database.SkillModels;
using APMApi.Models.Database.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APMApi.Context.Configurations.SkillConfigurations;

internal class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder
            .HasOne<Picture>(s => s.Picture)
            .WithMany()
            .HasForeignKey(s => s.PictureId)
            .HasConstraintName("FK_Skills_Pictures")
            .OnDelete(DeleteBehavior.SetNull);
        
        builder
            .HasMany<User>(s => s.Users)
            .WithMany(u => u.Skills)
            .UsingEntity(j => j.ToTable("UserSkills"));
        
        builder
            .HasMany<Request>(s => s.Requests)
            .WithMany(r => r.Skills)
            .UsingEntity(j => j.ToTable("RequestSkills"));
    }
}