using APMApi.Models.Database.ChatModels;
using APMApi.Models.Dto.ChatModels.Message;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainChats.MessageServices;

public class MessageService : BaseService<Message, MessageCreateDto, MessageUpdateDto>, IMessageService
{
    public MessageService(DataContext context) : base(context) { }
    
    
}