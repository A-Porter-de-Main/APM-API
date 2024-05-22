using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Models.Dto.RequestModels.Response;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.RequestModels;

[Table("Responses")]
public class Response : IBaseModel<Response, ResponseCreateDto, ResponseUpdateDto>
{
    public static Response Create(ResponseCreateDto createDto)
    {
        return new Response
        {
            Description = createDto.Description,
            RequestId = createDto.RequestId,
            UserId = createDto.UserId,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
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
    
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Column("content")] 
    [MaxLength(250)]
    public string Description { get; set; } = null!;
    
    [Column("request_id")]
    public Guid RequestId { get; set; }
    
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; init; }
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}