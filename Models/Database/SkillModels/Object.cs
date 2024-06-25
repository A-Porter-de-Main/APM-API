using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.CategoryDto.ObjectDto;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.SkillModels;

[Table("Objects")]
public class ObjectModel : IBaseModel<ObjectModel, ObjectCreateDto, ObjectUpdateDto>
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

    [Column("category_id")] [ForeignKey(nameof(CategoryId))] public Guid? CategoryId { get; set; }
    public ObjectCategory? Category { get; set; }
    
    public IEnumerable<User>? Users { get; set; }
    public IEnumerable<Request>? Requests { get; set; }

    #endregion

    #region Methods
    
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

    #endregion
}