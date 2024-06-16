using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Models.Dto.FeedBackModels.Issue;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.FeedBackModels;

[Table("Issues")]
public class Issue : IBaseModel<Issue, IssueCreateDto, IssueUpdateDto>
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Column("description")]
    [MaxLength(250)]
    public string Description { get; set; } = null!;

    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }

    public static Issue Create(IssueCreateDto createDto)
    {
        return new Issue
        {
            Description = createDto.Description,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public Issue Update(IssueUpdateDto updateDto)
    {
        Description = updateDto.Description;
        UpdatedAt = DateTime.Now;
        return this;
    }

    public static DbSet<Issue> GetDbSet(DataContext context)
    {
        return context.Issues;
    }
}