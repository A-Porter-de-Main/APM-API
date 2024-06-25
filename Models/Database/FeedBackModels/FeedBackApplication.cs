using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.FeedBackDto.FeedBackApplicationDto;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.FeedBackModels;

[Table("feedbacks_application")]
public class
    FeedBackApplication : IBaseModel<FeedBackApplication, FeedBackApplicationCreateDto, FeedBackApplicationUpdateDto>
{
    #region Fields

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

    #endregion
    
    #region Relations
    
    [Column("user_id")] public Guid? UserId { get; set; }
    [ForeignKey(nameof(UserId))] public User? User { get; set; }

    #endregion

    #region Methods

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

    #endregion
}