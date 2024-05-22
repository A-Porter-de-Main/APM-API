using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Models.Dto.CategoryModels.Object;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.SkillModels;

[Table("Objects")]
public class ObjectModel : IBaseModel<ObjectModel, ObjectCreateDto, ObjectUpdateDto>
{
    public static ObjectModel Create(ObjectCreateDto createDto)
    {
        return new ObjectModel
        {
            Name = createDto.Name,
            Description = createDto.Description,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public ObjectModel Update(ObjectUpdateDto updateDto)
    {
        Name = updateDto.Name;
        Description = updateDto.Description;
        UpdatedAt = DateTime.Now;
        return this;
    }

    public static DbSet<ObjectModel> GetDbSet(DataContext context)
    {
        return context.Objects;
    }
    
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }
    
    [Column("name")]
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    
    [Column("description")]
    [MaxLength(250)]
    public string Description { get; set; } = null!;
    
    [Column("created_at")]
    public DateTime CreatedAt { get; init; }
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}