using APMApi.Models.Database.ChatModels;
using APMApi.Models.Dto.ChatModels.Chat;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainChats.ChatServices;

public class ChatService : BaseService<Chat, ChatCreateDto, ChatUpdateDto>, IChatService
{
    public ChatService(DataContext context) : base(context) { }
}