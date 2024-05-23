using System.Diagnostics;
using APMApi.Helpers;
using APMApi.Models.Dto.UserModels.User;
using APMApi.Services.MainUsers.UserServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.UserControllers;

[ApiController]
[Route("api/v{version:apiVersion}/users")]
[ApiVersion("1.0")]
public class UserController : ControllerBaseExtended<Models.Database.UserModels.User, UserCreateDto, UserUpdateDto, IUserService>
{
    #region Fields

    private readonly IUserService _userService;

    #endregion

    #region Constructor

    public UserController(IUserService userService) : base(userService)
    {
        _userService = userService;
    }

    #endregion

    #region Methods
    
    [HttpPost("login")]
    [Authorize("visitor")]
    public async Task<IActionResult> Login(UserLoginDto userLoginDto)
    {
        return await TryExecuteControllerTask(async () =>
        {
            await ValidateDto(userLoginDto);
            return await _userService.Login(userLoginDto);
        });
    }
    
    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        return await TryExecuteControllerTask<dynamic>(async () =>
        {
            var id = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (id == null) return _userService.GenerateVisitor();
            return await _userService.GetById(Guid.Parse(id));
        });
    }

    [HttpGet("{id:guid}")]
    [Authorize("admin")]
    public override Task<IActionResult> GetById(Guid id) => base.GetById(id);
    
    [HttpGet]
    [Authorize("admin")]
    public override Task<IActionResult> GetAll() => base.GetAll();

    [HttpPost]
    [Authorize("visitor")]
    public override Task<IActionResult> Create(UserCreateDto createDto) => base.Create(createDto);
    
    [HttpPut("{id:guid}")]
    [Authorize("admin")]
    public override Task<IActionResult> Update(Guid id, UserUpdateDto updateDto) => base.Update(id, updateDto);
    
    [HttpDelete("{id:guid}")]
    [Authorize("admin")]
    public override Task<IActionResult> Delete(Guid id) => base.Delete(id);

    #endregion
}