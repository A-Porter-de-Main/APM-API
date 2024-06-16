using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Models.Dto.RequestModels.Request;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.RequestModels;

[Table("Requests")]
public class Request : IBaseModel<Request, RequestCreateDto, RequestUpdateDto>
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Column("description")]
    [MaxLength(250)]
    public string Description { get; set; } = null!;

    [Column("Deadline")] public DateTime Deadline { get; set; }

    [Column("PictureId")] public Guid? PictureId { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }

    public static Request Create(RequestCreateDto createDto)
    {
        return new Request
        {
            Description = createDto.Description,
            Deadline = createDto.Deadline,
            PictureId = createDto.PictureId,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public Request Update(RequestUpdateDto updateDto)
    {
        Description = updateDto.Description;
        Deadline = updateDto.Deadline;
        PictureId = updateDto.PictureId;
        UpdatedAt = DateTime.Now;
        return this;
    }

    public static DbSet<Request> GetDbSet(DataContext context)
    {
        return context.Requests;
    }
}