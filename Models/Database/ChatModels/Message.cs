using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Models.Dto.ChatModels.Message;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.ChatModels;

[Table("Messages")]
public class Message : IBaseModel<Message, MessageCreateDto, MessageUpdateDto>
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Column("content")] [MaxLength(250)] public string Content { get; set; } = null!;

    [Column("chat_id")] public Guid ChatId { get; set; }

    [Column("user_id")] public Guid UserId { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; init; }

    [Column("updated_at")] public DateTime UpdatedAt { get; set; }

    public static Message Create(MessageCreateDto createDto)
    {
        return new Message
        {
            Content = createDto.Content,
            ChatId = createDto.ChatId,
            UserId = createDto.UserId,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public Message Update(MessageUpdateDto updateDto)
    {
        Content = updateDto.Content;
        UpdatedAt = DateTime.Now;
        return this;
    }

    public static DbSet<Message> GetDbSet(DataContext context)
    {
        return context.Messages;
    }
}