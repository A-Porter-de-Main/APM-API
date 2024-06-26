using APMApi.Helpers;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserDto.ChatDto;
using APMApi.Services.MainChats.ChatServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.UserControllers;

[ApiController]
[Route("api/v{version:apiVersion}/chats")]
[ApiVersion("1.0")]
public class ChatsController : ControllerBaseExtended<Chat, ChatCreateDto, ChatUpdateDto, IChatService>
{
    public ChatsController(IChatService service) : base(service)
    {
    }
    
    public override Task<IActionResult> Update(Guid id, ChatUpdateDto updateDto)
    {
        return Task.FromResult<IActionResult>(BadRequest("Update method is not implemented"));
    }
}