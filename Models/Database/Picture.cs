using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Context;
using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Database.SkillModels;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.RequestDto.PictureDto;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database;

[Table("Pictures")]
public class Picture : IBaseModel<Picture, PictureCreateDto, PictureUpdateDto>
{
    #region Fields

    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Column("path")] [MaxLength(250)] public string Path { get; set; } = null!;

    [Column("description")]
    [MaxLength(250)]
    public string? Description { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }

    #endregion
    
    #region Relations

    public IEnumerable<User>? Users { get; }
    
    public IEnumerable<ObjectModel>? Objects { get; }
    
    public IEnumerable<Request>? Requests { get; }
    
    public IEnumerable<ObjectCategory>? ObjectCategories { get; }
    
    public IEnumerable<Skill>? Skills { get; }

    #endregion

    #region Methods

    public static Picture Create(PictureCreateDto createDto)
    {
        return new Picture
        {
            Path = createDto.Path,
            Description = createDto.Description,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public Picture Update(PictureUpdateDto updateDto)
    {
        Path = updateDto.Path;
        Description = updateDto.Description;
        UpdatedAt = DateTime.Now;
        return this;
    }

    public static DbSet<Picture> GetDbSet(DataContext context)
    {
        return context.Pictures;
    }

    #endregion
}