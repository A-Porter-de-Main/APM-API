using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Context;
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
    
    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }
    
    #endregion

    #region Relations

    [Column("picture_id")] public Guid? PictureId { get; set; }
    [ForeignKey(nameof(PictureId))] public Picture? Picture { get; }
    public IEnumerable<User>? Users { get; }
    public IEnumerable<Request>? Requests { get; }
    
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