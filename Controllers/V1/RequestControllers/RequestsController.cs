using APMApi.Helpers;
using APMApi.Models.Database;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestDto.RequestDto;
using APMApi.Models.Exception;
using APMApi.Services.MainRequests.RequestServices;
using APMApi.Services.Other.FileServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

    [HttpGet]
    [Authorize("admin")]
    public override Task<IActionResult> GetAll()
    {
        return base.GetAll();
    }
    
    [HttpGet("user/{id:guid}")]
    [Authorize("user")]
    public Task<IActionResult> GetAllScopedUser(Guid id)
    {
        return TryExecuteControllerTask(async () =>
        {
            if (User.Identity?.IsAuthenticated == false) throw new Exception("User is not authenticated");
            var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value!;
            if (id != Guid.Parse(userId)) throw new Exception("You are not allowed to get responses of this user");
            
            return await _requestService.GetAllScopedUser(id);
        });
    }
    
    [HttpGet("{id:guid}")]
    [Authorize("user")]
    public override Task<IActionResult> GetById(Guid id)
    {
        return TryExecuteControllerTask(async () =>
        {
            var result = await _requestService.GetById(id);
            if (result == null) throw new NotFoundException("Request not found");
            
            result.Pictures = result.Pictures?.Select(p => new Picture
            {
                Id = p.Id,
                Path = _fileService.GetRightUrl(HttpContext.Request, p.Path)
            });
            return result;
        });
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
            var result = await _requestService.Create(createDto);
            result.Pictures = result.Pictures?.Select(p => new Picture
            {
                Id = p.Id,
                Path = _fileService.GetRightUrl(HttpContext.Request, p.Path)
            });
            return result;
        });
    }

    [HttpPut("{id:guid}")]
    [Authorize("user")]
    public override Task<IActionResult> Update(Guid id, [FromForm] RequestUpdateDto updateDto)
    {
        return TryExecuteControllerTask(async () =>
        {
            if (User.Identity?.IsAuthenticated == false) throw new Exception("User is not authenticated");
            var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value!;
            var request = await _requestService.GetById(id) ?? throw new NotFoundException("Request not found");
            if (request.UserId != Guid.Parse(userId)) throw new Exception("User is not owner of this request");

            if (updateDto.Pictures.IsNullOrEmpty()) return await _requestService.Update(id, updateDto);
            _fileService.DeleteManyDocuments(request.Pictures!);
            updateDto.PicturesCreated = await _fileService.AddMultipleDocuments(updateDto.Pictures!);
            
            var result = await _requestService.Update(id, updateDto);
            if (result == null) throw new Exception("Request not updated");
            
            result.Pictures = result.Pictures?.Select(p => new Picture
            {
                Id = p.Id,
                Path = _fileService.GetRightUrl(HttpContext.Request, p.Path)
            });
            return result;
        });
    }
    
    [HttpDelete("{id:guid}")]
    [Authorize("user")]
    public override Task<IActionResult> Delete(Guid id)
    {
        return TryExecuteControllerTask(async () =>
        {
            if (User.Identity?.IsAuthenticated == false) throw new Exception("User is not authenticated");
            var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value!;
            var request = await _requestService.GetById(id) ?? throw new NotFoundException("Request not found");
            
            if (request.UserId != Guid.Parse(userId)) throw new Exception("User is not owner of this request");
            _fileService.DeleteManyDocuments(request.Pictures!);
            
            return await _requestService.Delete(id);
        });
    }
}