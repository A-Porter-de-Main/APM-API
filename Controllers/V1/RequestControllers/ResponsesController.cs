using APMApi.Helpers;
using APMApi.Models;
using APMApi.Models.Database;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestDto.ResponseDto;
using APMApi.Models.Exception;
using APMApi.Services.MainRequests.ResponseServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.RequestControllers;

[ApiController]
[Route("api/v{version:apiVersion}/responses")]
[ApiVersion("1.0")]
public class ResponsesController : ControllerBaseExtended<Response, ResponseCreateDto, ResponseUpdateDto, IResponseService>
{
    #region Fields

    private readonly IResponseService _responseService;

    #endregion

    #region Constructor

    public ResponsesController(IResponseService responseService) : base(responseService)
    {
        _responseService = responseService;
    }

    #endregion

    #region Methods

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
            
            return await _responseService.GetAllScopedUser(id);
        });
    }
    
    [HttpGet("request/{id:guid}")]
    [Authorize("user")]
    public Task<IActionResult> GetAllScopedRequest(Guid id)
    {
        return TryExecuteControllerTask(async () =>
        {
            if (User.Identity?.IsAuthenticated == false) throw new Exception("User is not authenticated");
            return await _responseService.GetAllScopedRequest(id);
        });
    }
    
    [HttpPost]
    [Authorize("user")]
    public override Task<IActionResult> Create([FromForm] ResponseCreateDto createDto)
    {
        return TryExecuteControllerTask(async () =>
        {
            if (User.Identity?.IsAuthenticated == false) throw new Exception("User is not authenticated");
            var id = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value!;
            createDto.UserId = Guid.Parse(id);
            await ValidateDto(createDto);
            
            return await _responseService.Create(createDto);
        });
    }
    
    [HttpPut("{id:guid}")]
    [Authorize("user")]
    public override Task<IActionResult> Update(Guid id, [FromForm] ResponseUpdateDto updateDto)
    {
        return TryExecuteControllerTask(async () =>
        {
            if (User.Identity?.IsAuthenticated == false) throw new Exception("User is not authenticated");
            var response = await _responseService.GetById(id);
            if (response == null) throw new NotFoundException("Response not found");
            
            var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value!;
            if (response.UserId != Guid.Parse(userId)) throw new Exception("You are not allowed to update this response");
            
            await ValidateDto(updateDto);
            return await _responseService.Update(id, updateDto);
        });
    }
    
    [HttpDelete("{id:guid}")]
    [Authorize("user")]
    public override Task<IActionResult> Delete(Guid id)
    {
        return TryExecuteControllerTask(async () =>
        {
            if (User.Identity?.IsAuthenticated == false) throw new Exception("User is not authenticated");
            var response = await _responseService.GetById(id);
            if (response == null) throw new NotFoundException("Response not found");
            
            var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value!;
            if (response.UserId != Guid.Parse(userId)) throw new Exception("You are not allowed to delete this response");
            
            await _responseService.Delete(id);
            return Ok();
        });
    }

    #endregion
}