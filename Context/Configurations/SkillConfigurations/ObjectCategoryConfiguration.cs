using APMApi.Models.Database;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Database.SkillModels;
using APMApi.Models.Database.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APMApi.Context.Configurations.SkillConfigurations;

internal class ObjectCategoryConfiguration : IEntityTypeConfiguration<ObjectCategory>
{
    public void Configure(EntityTypeBuilder<ObjectCategory> builder)
    {
        builder
            .HasOne<Picture>(oc => oc.Picture)
            .WithMany()
            .HasForeignKey(oc => oc.PictureId)
            .HasConstraintName("FK_ObjectCategories_Pictures")
            .OnDelete(DeleteBehavior.SetNull);
        
        builder
            .HasOne<ObjectCategory>(oc => oc.Parent)
            .WithMany(oc => oc.Children)
            .HasForeignKey(oc => oc.ParentId)
            .HasConstraintName("FK_ObjectCategories_ObjectCategories")
            .OnDelete(DeleteBehavior.SetNull);
        
        builder
            .HasMany<ObjectModel>(oc => oc.Objects)
            .WithOne(o => o.Category)
            .HasForeignKey(o => o.CategoryId)
            .HasConstraintName("FK_Objects_ObjectCategories")
            .OnDelete(DeleteBehavior.Cascade);
    }
}