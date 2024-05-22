using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Models.Dto.RequestModels.Picture;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.RequestModels;

[Table("Pictures")]
public class Picture : IBaseModel<Picture, PictureCreateDto, PictureUpdateDto>
{
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
    
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }
    
    [Column("path")]
    [MaxLength(250)]
    public string Path { get; set; } = null!;
    
    [Column("description")]
    [MaxLength(250)]
    public string? Description { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; init; }
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}