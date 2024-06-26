using APMApi.Helpers;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestDto.RequestDto;
using APMApi.Services.MainRequests.RequestServices;
using APMApi.Services.Other.FileServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.RequestControllers;

[ApiController]
[Route("api/v{version:apiVersion}/requests")]
[ApiVersion("1.0")]
public class RequestController : ControllerBaseExtended<Request, RequestCreateDto, RequestUpdateDto, IRequestService>
{
    #region Fields

    private readonly IRequestService _requestService;
    private readonly IFileService _fileService;

    #endregion
    
    public RequestController(IRequestService requestService, IFileService fileService) : base(requestService)
    {
        _requestService = requestService;
        _fileService = fileService;
    }

    [HttpPost]
    [Authorize("user")]
    public override Task<IActionResult> Create([FromForm] RequestCreateDto createDto)
    {
        return TryExecuteControllerTask(async () =>
        {
            if (User.Identity?.IsAuthenticated == false) throw new Exception("User is not authenticated");
            var id = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value!;
            createDto.UserId = Guid.Parse(id);
            createDto.PicturesCreated = await _fileService.AddMultipleDocuments(createDto.Pictures);
            
            await ValidateDto(createDto);
            return await _requestService.Create(createDto);
        });
    }
}