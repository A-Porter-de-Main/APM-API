using APMApi.Models.Database.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APMApi.Context.Configurations.UserConfigurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasOne(u => u.Role)
            .WithMany()
            .HasForeignKey(u => u.RoleId)
            .HasConstraintName("FK_Users_Roles")
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasOne(u => u.Picture)
            .WithMany()
            .HasForeignKey(u => u.PictureId)
            .HasConstraintName("FK_Users_Pictures")
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasMany(u => u.Addresses)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .HasConstraintName("FK_Addresses_Users")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasOne(u => u.Preference)
            .WithOne(p => p.User)
            .HasForeignKey<User>(u => u.Id)
            .HasConstraintName("FK_Preferences_Users")
            .OnDelete(DeleteBehavior.Cascade);

        builder.UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasMany(u => u.FeedBacks)
            .WithOne(f => f.User)
            .HasForeignKey(f => f.UserId)
            .HasConstraintName("FK_FeedBacks_Users")
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasMany(u => u.FeedBackApplications)
            .WithOne(f => f.User)
            .HasForeignKey(f => f.UserId)
            .HasConstraintName("FK_FeedBackApplications_Users")
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasMany(u => u.Issues)
            .WithOne(i => i.User)
            .HasForeignKey(i => i.UserId)
            .HasConstraintName("FK_Issues_Users")
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasMany(u => u.Skills)
            .WithMany(s => s.Users)
            .UsingEntity(j => j.ToTable("UserSkills"));

        builder.UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasMany(u => u.Objects)
            .WithMany(o => o.Users)
            .UsingEntity(j => j.ToTable("UserObjects"));
    }
}