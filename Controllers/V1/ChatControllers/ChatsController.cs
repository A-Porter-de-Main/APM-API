using APMApi.Helpers;
using APMApi.Models.Dto.ChatModels.Chat;
using APMApi.Services.MainChats.ChatServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.ChatControllers;

[ApiController]
[Route("api/v{version:apiVersion}/chats")]
[ApiVersion("1.0")]
public class ChatsController : ControllerBaseExtended<Models.Database.ChatModels.Chat, ChatCreateDto, ChatUpdateDto, IChatService>
{
    public ChatsController(IChatService service) : base(service) { }
}