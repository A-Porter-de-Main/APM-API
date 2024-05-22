using APMApi.Models.Database.ChatModels;
using APMApi.Models.Dto.ChatModels.Chat;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainChats.ChatServices;

public interface IChatService : IBaseService<Chat, ChatCreateDto, ChatUpdateDto> { }