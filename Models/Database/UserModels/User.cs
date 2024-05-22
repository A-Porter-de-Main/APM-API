using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using APMApi.Models.Dto.UserModels.User;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.UserModels;

[Table("Users")]
[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Phone), IsUnique = true)]
public class User : IBaseModel<User, UserCreateDto, UserUpdateDto>
{
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
    
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }
    
    [Column("firstname")]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    
    [Column("lastname")]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;
    
    [Column("desciption")]
    [MaxLength(250)]
    public string? Description { get; set; }
    
    [Column("email")]
    [MaxLength(250)]
    public string Email { get; set; } = null!;
    
    [Column("phone")]
    [MaxLength(20)]
    public string Phone { get; set; } = null!;
    
    [Column("password")]
    [MaxLength(250)]
    [JsonIgnore]
    public string Password { get; set; } = null!;
    
    [Column("strip_user_id")]
    public string? StripUserId { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; init; }
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}