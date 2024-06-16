using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Models.Dto.RequestModels.Status;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.RequestModels;

[Table("Statuses")]
public class Status : IBaseModel<Status, StatusCreateDto, StatusUpdateDto>
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Column("name")] [MaxLength(50)] public string Name { get; set; } = null!;

    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }

    public static Status Create(StatusCreateDto createDto)
    {
        return new Status
        {
            Name = createDto.Name,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public Status Update(StatusUpdateDto updateDto)
    {
        Name = updateDto.Name;
        UpdatedAt = DateTime.Now;
        return this;
    }

    public static DbSet<Status> GetDbSet(DataContext context)
    {
        return context.Statuses;
    }
}