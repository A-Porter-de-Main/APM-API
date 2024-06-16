using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Models.Dto.FeedBackModels.FeedBackApplication;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.FeedBackModels;

[Table("feedbacks_application")]
public class
    FeedBackApplication : IBaseModel<FeedBackApplication, FeedBackApplicationCreateDto, FeedBackApplicationUpdateDto>
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Column("description")]
    [MaxLength(250)]
    public string Description { get; set; } = null!;

    [Column("Note")] public int Note { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }

    public static FeedBackApplication Create(FeedBackApplicationCreateDto dto)
    {
        return new FeedBackApplication
        {
            Description = dto.Description,
            Note = dto.Note,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public FeedBackApplication Update(FeedBackApplicationUpdateDto dto)
    {
        Description = dto.Description;
        Note = dto.Note;
        UpdatedAt = DateTime.Now;
        return this;
    }

    public static DbSet<FeedBackApplication> GetDbSet(DataContext context)
    {
        return context.FeedBacksApplication;
    }
}