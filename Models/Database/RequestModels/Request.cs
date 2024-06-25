using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Context;
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

    [Column("description")]
    [MaxLength(250)]
    public string Description { get; set; } = null!;

    [Column("deadline")] public DateTime Deadline { get; set; }
    
    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }

    #endregion
    
    #region Relations

    [Column("status_id")] public Guid StatusId { get; }
    [ForeignKey(nameof(StatusId))] public Status Status { get; } = null!;
    
    public IEnumerable<Picture>? Pictures { get; }
    
    public IEnumerable<Response>? Responses { get; }
    
    public IEnumerable<Skill>? Skills { get; }
    
    public IEnumerable<ObjectModel>? Objects { get; }

    #endregion

    #region Methods

    public static Request Create(RequestCreateDto createDto)
    {
        return new Request
        {
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