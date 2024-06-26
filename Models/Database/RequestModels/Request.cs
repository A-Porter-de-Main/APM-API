using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using APMApi.Models.Database.SkillModels;
using APMApi.Models.Dto.RequestDto.RequestDto;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.RequestModels;

[Table("Requests")]
public class Request : IBaseModel<Request, RequestCreateDto, RequestUpdateDto>
{
    #region Fields

    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Column("title")]
    [MaxLength(50)]
    public string Title { get; set; } = null!;
    
    [Column("description")]
    [MaxLength(250)]
    public string Description { get; set; } = null!;

    [NotMapped] public string? StatusName => Status?.Name;
    
    [Column("deadline")] public DateTime Deadline { get; set; }
    
    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }

    #endregion
    
    #region Relations

    [JsonIgnore] [Column("status_id")] public Guid? StatusId { get; set; }
    [JsonIgnore] [ForeignKey(nameof(StatusId))] public Status? Status { get; set; }
    
    public IEnumerable<Picture>? Pictures { get; set; }
    
    public IEnumerable<Response>? Responses { get; set; }
    
    public IEnumerable<Skill>? Skills { get; set; }
    
    public IEnumerable<ObjectModel>? Objects { get; set; }

    #endregion

    #region Methods

    public static Request Create(RequestCreateDto createDto)
    {
        return new Request
        {
            Title = createDto.Title,
            Description = createDto.Description,
            Deadline = createDto.Deadline,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public Request Update(RequestUpdateDto updateDto)
    {
        Description = updateDto.Description;
        Deadline = updateDto.Deadline;
        UpdatedAt = DateTime.Now;
        return this;
    }

    public static DbSet<Request> GetDbSet(DataContext context)
    {
        return context.Requests;
    }

    #endregion
}