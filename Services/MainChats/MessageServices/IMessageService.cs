using APMApi.Models.Database.ChatModels;
using APMApi.Models.Dto.ChatModels.Message;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainChats.MessageServices;

public interface IMessageService : IBaseService<Message, MessageCreateDto, MessageUpdateDto>
{
}