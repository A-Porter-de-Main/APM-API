using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Context;
using APMApi.Models.Dto.CategoryDto.TypeDto;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.SkillModels;

[Table("ObjectCategories")]
public class ObjectCategory : IBaseModel<ObjectCategory, ObjectCategoryCreateDto, ObjectCategoryUpdateDto>
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

    [Column("parent_id")] [ForeignKey(nameof(ParentId))] public Guid? ParentId { get; set; }
    public ObjectCategory? Parent { get; }

    public IEnumerable<ObjectModel>? Objects { get; }
    
    public IEnumerable<ObjectCategory>? Children { get; }

    #endregion

    #region Methods
    
    public static ObjectCategory Create(ObjectCategoryCreateDto createDto)
    {
        return new ObjectCategory
        {
            Name = createDto.Name,
            Description = createDto.Description,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public ObjectCategory Update(ObjectCategoryUpdateDto updateDto)
    {
        Name = updateDto.Name;
        Description = updateDto.Description;
        UpdatedAt = DateTime.Now;
        return this;
    }

    public static DbSet<ObjectCategory> GetDbSet(DataContext context)
    {
        return context.Types;
    }

    #endregion
}