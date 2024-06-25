using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Models.Dto.UserDto.PreferenceDto;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.UserModels;

[Table("Preferences")]
public class Preference : IBaseModel<Preference, PreferenceCreateDto, PreferenceUpdateDto>
{
    #region Fields
    
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Column("by_mail")] public bool ByMail { get; set; }

    [Column("by_notifications")] public bool ByNotifications { get; set; }

    [Column("by_phone")] public bool ByPhone { get; set; }


    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }

    #endregion

    #region Relations
    
    [Column("user_id")] public Guid? UserId { get; set; }
    [ForeignKey(nameof(UserId))] public User? User { get; set; }

    #endregion

    #region Methods
    
    public static Preference Create(PreferenceCreateDto createDto)
    {
        return new Preference
        {
            ByMail = createDto.ByMail,
            ByNotifications = createDto.ByNotifications,
            ByPhone = createDto.ByPhone,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public Preference Update(PreferenceUpdateDto updateDto)
    {
        ByMail = updateDto.ByMail;
        ByNotifications = updateDto.ByNotifications;
        ByPhone = updateDto.ByPhone;
        UpdatedAt = DateTime.Now;
        return this;
    }

    public static DbSet<Preference> GetDbSet(DataContext context)
    {
        return context.Preferences;
    }

    #endregion
}