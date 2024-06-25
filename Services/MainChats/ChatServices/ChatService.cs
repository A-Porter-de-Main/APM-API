using APMApi.Context;
using APMApi.Models;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserModels.ChatDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainChats.ChatServices;

public class ChatService : BaseService<Chat, ChatCreateDto, ChatUpdateDto>, IChatService
{
    public ChatService(DataContext context) : base(context)
    {
    }
}