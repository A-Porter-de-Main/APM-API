using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using APMApi.Models.Dto.UserDto.RoleDto;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.UserModels;

[Table("Roles")]
[Index(nameof(Name), IsUnique = true)]
public class Role : IBaseModel<Role, RoleCreateDto, RoleUpdateDto>
{
    #region Fields

    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Column("name")] [MaxLength(50)] public string Name { get; set; } = null!;

    [Column("created_at")] public DateTime CreatedAt { get; init; }
    
    #endregion

    #region Relations
    
    [JsonIgnore]
    public IEnumerable<User>? Users { get; set; }

    #endregion

    #region Methods
    
    public static Role Create(RoleCreateDto createDto)
    {
        return new Role
        {
            Name = createDto.Name,
            CreatedAt = DateTime.Now
        };
    }

    public Role Update(RoleUpdateDto updateDto)
    {
        Name = updateDto.Name;
        return this;
    }

    public static DbSet<Role> GetDbSet(DataContext context)
    {
        return context.Roles;
    }

    #endregion
    
}