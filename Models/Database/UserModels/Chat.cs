using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.UserDto.ChatDto;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Database.UserModels;

[Table("Chats")]
[Index(nameof(ResponseId), IsUnique = true)]
public class Chat : IBaseModel<Chat, ChatCreateDto, ChatUpdateDto>
{
    #region Fields

    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }
    
    [Column("created_at")] public DateTime CreatedAt { get; init; }
    
    #endregion

    #region Relations

    [Column("response_id")] public Guid? ResponseId { get; set; }
    [ForeignKey(nameof(ResponseId))] public Response? Response { get; set; }

    #endregion
    
    #region Methods

    public static Chat Create(ChatCreateDto createDto)
    {
        return new Chat
        {
            ResponseId = createDto.ResponseId,
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

    #endregion

}