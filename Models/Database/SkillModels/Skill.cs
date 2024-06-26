using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.CategoryDto.SkillDto;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.SkillModels;

[Table("Skills")]
public class Skill : IBaseModel<Skill, SkillCreateDto, SkillUpdateDto>
{
    #region Fields
    
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Column("name")] [MaxLength(50)] public string Name { get; set; } = null!;

    [Column("description")]
    [MaxLength(250)]
    public string Description { get; set; } = null!;
    
    [Column("picture_path")] [MaxLength(150)] public string? PicturePath { get; set; }
    
    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }
    
    #endregion

    #region Relations

    [Column("parent_id")] public Guid? ParentId { get; set; }
    [ForeignKey(nameof(ParentId))] public Skill? Parent { get; set; }
    
    public IEnumerable<Skill>? Children { get; set; }
    public IEnumerable<User>? Users { get; set; }
    public IEnumerable<Request>? Requests { get; set; }
    
    #endregion

    #region Methods
    
    public static Skill Create(SkillCreateDto dto)
    {
        return new Skill
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public Skill Update(SkillUpdateDto dto)
    {
        Name = dto.Name;
        Description = dto.Description;
        UpdatedAt = DateTime.Now;
        return this;
    }

    public static DbSet<Skill> GetDbSet(DataContext context)
    {
        return context.Skills;
    }

    #endregion
}