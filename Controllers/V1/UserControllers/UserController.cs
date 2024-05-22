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
    public async Task<IActionResult> Login(UserLoginDto userLoginDto)
    {
        return await TryExecuteControllerTask(async () =>
        {
            await ValidateDto(userLoginDto);
            return await _userService.Login(userLoginDto);
        });
    }
    
    [HttpGet("me")]
    [Authorize("admin")]
    public async Task<IActionResult> Me()
    {
        return await TryExecuteControllerTask(async () =>
        {
            var id = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "id")?.Value ?? throw new Exception("User id not found"));
            return await _userService.GetById(id);
        });
    }

    [HttpGet("{id:guid}")]
    [Authorize("superAdmin")]
    public override Task<IActionResult> GetById(Guid id) => base.GetById(id);
    
    [HttpGet]
    [Authorize("superAdmin")]
    public override Task<IActionResult> GetAll() => base.GetAll();
    
    [HttpPost]
    [Authorize("superAdmin")]
    public override Task<IActionResult> Create(UserCreateDto createDto) => base.Create(createDto);
    
    [HttpPut("{id:guid}")]
    [Authorize("superAdmin")]
    public override Task<IActionResult> Update(Guid id, UserUpdateDto updateDto) => base.Update(id, updateDto);
    
    [HttpDelete("{id:guid}")]
    [Authorize("superAdmin")]
    public override Task<IActionResult> Delete(Guid id) => base.Delete(id);

    #endregion
}