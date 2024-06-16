using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Models.Dto.FeedBackModels.FeedBack;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.FeedBackModels;

[Table("feedbacks")]
public class FeedBack : IBaseModel<FeedBack, FeedBackCreateDto, FeedBackUpdateDto>
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

    public static FeedBack Create(FeedBackCreateDto createDto)
    {
        return new FeedBack
        {
            Description = createDto.Description,
            Note = createDto.Note,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public FeedBack Update(FeedBackUpdateDto updateDto)
    {
        Description = updateDto.Description;
        Note = updateDto.Note;
        UpdatedAt = DateTime.Now;
        return this;
    }

    public static DbSet<FeedBack> GetDbSet(DataContext context)
    {
        return context.FeedBacks;
    }
}