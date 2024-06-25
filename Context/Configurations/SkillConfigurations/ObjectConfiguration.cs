using APMApi.Models.Database;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Database.SkillModels;
using APMApi.Models.Database.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APMApi.Context.Configurations.SkillConfigurations;

internal class ObjectConfiguration : IEntityTypeConfiguration<ObjectModel>
{
    public void Configure(EntityTypeBuilder<ObjectModel> builder)
    {
        builder
            .HasOne<Picture>(o => o.Picture)
            .WithMany()
            .HasForeignKey(o => o.PictureId)
            .HasConstraintName("FK_Objects_Pictures")
            .OnDelete(DeleteBehavior.SetNull);
        
        builder
            .HasOne(s => s.Category)
            .WithMany(c => c.Objects)
            .HasForeignKey(s => s.CategoryId)
            .HasConstraintName("FK_Objects_ObjectCategories")
            .OnDelete(DeleteBehavior.Cascade);
    }
}