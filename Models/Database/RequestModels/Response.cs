using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Context;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.RequestDto.ResponseDto;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.RequestModels;

[Table("Responses")]
public class Response : IBaseModel<Response, ResponseCreateDto, ResponseUpdateDto>
{
    #region Fields
    
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Column("content")] [MaxLength(250)] public string Description { get; set; } = null!;
    
    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }

    #endregion

    #region Relations

    [Column("request_id")] [ForeignKey(nameof(RequestId))] public Guid RequestId { get; set; }
    public Request Request { get; } = null!;

    [Column("user_id")] [ForeignKey(nameof(UserId))] public Guid UserId { get; set; }
    public User User { get; } = null!;

    [Column("response_status_id")] public Guid StatusId { get; set; }
    [ForeignKey(nameof(StatusId))] public ResponseStatus Status { get; } = null!;
    
    public Chat? Chat { get; }

    #endregion

    #region Methods
    
    public static Response Create(ResponseCreateDto createDto)
    {
        return new Response
        {
            Description = createDto.Description,
            RequestId = createDto.RequestId,
            UserId = createDto.UserId,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public Response Update(ResponseUpdateDto updateDto)
    {
        Description = updateDto.Description;
        UpdatedAt = DateTime.Now;
        return this;
    }

    public static DbSet<Response> GetDbSet(DataContext context)
    {
        return context.Responses;
    }

    #endregion
}