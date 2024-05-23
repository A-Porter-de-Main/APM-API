using APMApi.Helpers;
using APMApi.Models.Database.ChatModels;
using APMApi.Models.Dto.ChatModels.Message;
using APMApi.Services.MainChats.MessageServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.ChatControllers;

[ApiController]
[Route("api/v{version:apiVersion}/messages")]
[ApiVersion("1.0")]
public class MessagesController : ControllerBaseExtended<Message, MessageCreateDto, MessageUpdateDto, IMessageService>
{
    public MessagesController(IMessageService service) : base(service) { }
}