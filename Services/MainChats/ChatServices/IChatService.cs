using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserDto.ChatDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainChats.ChatServices;

public interface IChatService : IBaseService<Chat, ChatCreateDto, ChatUpdateDto>
{
}