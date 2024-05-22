using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Models.Dto.ChatModels.Chat;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.ChatModels;

[Table("Chats")]
public class Chat : IBaseModel<Chat, ChatCreateDto, ChatUpdateDto>
{
    public static Chat Create(ChatCreateDto createDto)
    {
        return new Chat
        {
            CreatedAt = DateTime.Now
        };
    }

    public Chat Update(ChatUpdateDto updateDto)
    {
        throw new NotImplementedException();
    }

    public static DbSet<Chat> GetDbSet(DataContext context)
    {
        return context.Chats;
    }
    
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; init; }
}