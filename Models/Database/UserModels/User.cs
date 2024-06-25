using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using APMApi.Context;
using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Database.SkillModels;
using APMApi.Models.Dto.UserModels.UserDto;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.UserModels;

[Table("Users")]
[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Phone), IsUnique = true)]
public class User : IBaseModel<User, UserCreateDto, UserUpdateDto>
{
    #region Fields

    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Column("firstname")] [MaxLength(50)] public string FirstName { get; set; } = null!;

    [Column("lastname")] [MaxLength(50)] public string LastName { get; set; } = null!;

    [Column("description")]
    [MaxLength(250)]
    public string? Description { get; set; }

    [Column("email")] [MaxLength(250)] public string Email { get; set; } = null!;

    [Column("phone")] [MaxLength(20)] public string Phone { get; set; } = null!;

    [Column("password")]
    [MaxLength(250)]
    [JsonIgnore]
    public string Password { get; set; } = null!;

    [Column("strip_user_id")] public Guid? StripUserId { get; set; }
    
    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }
    
    #endregion
    
    #region Relations
    
    [Column("role_id")] public Guid RoleId { get; }
    [ForeignKey(nameof(RoleId))] public Role Role { get; } = null!;
    [Column("picture_id")] public Guid? PictureId { get; }
    [ForeignKey(nameof(PictureId))] public Picture? Picture { get; }
    
    public IEnumerable<Address>? Addresses { get; }
    public Preference Preference { get; } = null!;
    public IEnumerable<Skill>? Skills { get; }
    public IEnumerable<FeedBack>? FeedBacks { get; }
    public IEnumerable<FeedBackApplication>? FeedBackApplications { get; }
    public IEnumerable<Issue>? Issues { get; }
    public IEnumerable<ObjectModel>? Objects { get; }

    #endregion
    
    #region Methods

    public static User Create(UserCreateDto userCreateDto)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            FirstName = userCreateDto.FirstName,
            LastName = userCreateDto.LastName,
            Email = userCreateDto.Email,
            Phone = userCreateDto.Phone,
            Password = userCreateDto.Password,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public User Update(UserUpdateDto userUpdateDto)
    {
        FirstName = userUpdateDto.FirstName;
        LastName = userUpdateDto.LastName;
        Email = userUpdateDto.Email;
        Phone = userUpdateDto.Phone;
        UpdatedAt = DateTime.Now;
        return this;
    }

    public static DbSet<User> GetDbSet(DataContext context)
    {
        return context.Users;
    }

    #endregion
}