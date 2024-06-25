using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Context;
using APMApi.Models.Dto.RequestDto.ResponseStatusDto;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.RequestModels;

[Table("ResponseStatuses")]
public class ResponseStatus : IBaseModel<ResponseStatus, ResponseStatusCreateDto, ResponseStatusUpdateDto>
{
    #region Fields

    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Column("name")] [MaxLength(50)] public string Name { get; set; } = null!;

    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }
    
    #endregion

    #region Relations

    public IEnumerable<Response>? Responses { get; }

    #endregion

    #region Methods

    public static ResponseStatus Create(ResponseStatusCreateDto createDto)
    {
        return new ResponseStatus
        {
            Name = createDto.Name,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public ResponseStatus Update(ResponseStatusUpdateDto updateDto)
    {
        Name = updateDto.Name;
        UpdatedAt = DateTime.Now;
        return this;
    }

    public static DbSet<ResponseStatus> GetDbSet(DataContext context)
    {
        return context.ResponseStatuses;
    }

    #endregion
}