using APMApi.Models.Database.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APMApi.Context.Configurations.UserConfigurations;

internal class PreferenceConfiguration : IEntityTypeConfiguration<Preference>
{
    public void Configure(EntityTypeBuilder<Preference> builder)
    {
        builder.HasOne(p => p.User)
            .WithOne(u => u.Preference)
            .HasForeignKey<Preference>(p => p.UserId)
            .HasConstraintName("FK_Preferences_Users")
            .OnDelete(DeleteBehavior.Cascade);
    }
}