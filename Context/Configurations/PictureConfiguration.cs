using APMApi.Models.Database;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Database.SkillModels;
using APMApi.Models.Database.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APMApi.Context.Configurations;

internal class PictureConfigurations : IEntityTypeConfiguration<Picture>
{
    public void Configure(EntityTypeBuilder<Picture> builder)
    {
        builder
            .HasMany<ObjectModel>(p => p.Objects)
            .WithOne()
            .HasConstraintName("FK_Objects_Pictures")
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasMany<User>(p => p.Users)
            .WithOne()
            .HasConstraintName("FK_Users_Pictures")
            .OnDelete(DeleteBehavior.SetNull);
        
        builder
            .HasMany<Request>(p => p.Requests)
            .WithMany(r => r.Pictures)
            .UsingEntity(j => j.ToTable("RequestPictures"));
        
        builder
            .HasMany<Skill>(p => p.Skills)
            .WithOne()
            .HasConstraintName("FK_Skills_Pictures")
            .OnDelete(DeleteBehavior.SetNull);
        
        builder
            .HasMany<ObjectCategory>(p => p.ObjectCategories)
            .WithOne()
            .HasConstraintName("FK_ObjectCategories_Pictures")
            .OnDelete(DeleteBehavior.SetNull);
    }
}