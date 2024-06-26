using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Database.SkillModels;
using APMApi.Models.Dto.UserDto.UserDto;
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

    [NotMapped] public string? RoleName => Role?.Name;
    
    [Column("phone")] [MaxLength(20)] public string Phone { get; set; } = null!;

    [Column("password")]
    [MaxLength(250)]
    [JsonIgnore]
    public string Password { get; set; } = null!;

    [Column("strip_user_id")] public Guid? StripUserId { get; set; }
    
    [Column("picture_path")] [MaxLength(150)] public string PicturePath { get; set; } = null!;
    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }
    
    #endregion
    
    #region Relations
    
    [JsonIgnore] [Column("role_id")] public Guid? RoleId { get; set; }
    [JsonIgnore] [ForeignKey(nameof(RoleId))] public Role? Role { get; set; }
    
    public IEnumerable<Address>? Addresses { get; set; }
    public Preference? Preference { get; set; }
    public IEnumerable<Skill>? Skills { get; set; }
    public IEnumerable<FeedBack>? FeedBacks { get; set; }
    public IEnumerable<FeedBackApplication>? FeedBackApplications { get; set; }
    public IEnumerable<Issue>? Issues { get; set; }
    public IEnumerable<ObjectModel>? Objects { get; set; }

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
            PicturePath = userCreateDto.ImagePath!,
            Phone = userCreateDto.Phone,
            Password = userCreateDto.Password,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public User Update(UserUpdateDto userUpdateDto)
    {
        FirstName = userUpdateDto.FirstName ?? FirstName;
        LastName = userUpdateDto.LastName ?? LastName;
        Email = userUpdateDto.Email ?? Email;
        Phone = userUpdateDto.Phone ?? Phone;
        PicturePath = userUpdateDto.ImagePath ?? PicturePath;
        UpdatedAt = DateTime.Now;
        return this;
    }

    public static DbSet<User> GetDbSet(DataContext context)
    {
        return context.Users;
    }

    #endregion
}