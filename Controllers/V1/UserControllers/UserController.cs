using APMApi.Helpers;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserModels.User;
using APMApi.Models.Other;
using APMApi.Services.MainUsers.UserServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.UserControllers;

[ApiController]
[Route("api/v{version:apiVersion}/users")]
[ApiVersion("1.0")]
public class UserController : ControllerBaseExtended<User, UserCreateDto, UserUpdateDto, IUserService>
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
            var userToken = await _userService.Login(userLoginDto);
            if (userToken == null) return null;
            HttpContext.Response.Cookies.Append("dXNlclRva2Vu", userToken.Token);
            return userToken;
        });
    }

    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        return await TryExecuteControllerTask<dynamic>(async () =>
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                var id = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
                if (id != null) return await _userService.GetById(Guid.Parse(id));
            }
            var visitorToken = _userService.GenerateVisitor();
            HttpContext.Response.Cookies.Append("dXNlclRva2Vu", visitorToken.Token);
            return visitorToken;
        });
    }
    
    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        return await TryExecuteControllerTask(() =>
        {
            if (User.Identity?.IsAuthenticated == false) throw new Exception("User is not authenticated");
            HttpContext.Response.Cookies.Delete("dXNlclRva2Vu");
            return Task.FromResult(true);
        });
    }
    
    [HttpGet("{id:guid}")]
    [Authorize("admin")]
    public override Task<IActionResult> GetById(Guid id)
    {
        return base.GetById(id);
    }

    [HttpGet]
    [Authorize("admin")]
    public override Task<IActionResult> GetAll()
    {
        return base.GetAll();
    }

    [HttpPost]
    [Authorize("visitor")]
    public override Task<IActionResult> Create(UserCreateDto createDto)
    {
        return base.Create(createDto);
    }

    [HttpPut("{id:guid}")]
    [Authorize("admin")]
    public override Task<IActionResult> Update(Guid id, UserUpdateDto updateDto)
    {
        return base.Update(id, updateDto);
    }

    [HttpDelete("{id:guid}")]
    [Authorize("admin")]
    public override Task<IActionResult> Delete(Guid id)
    {
        return base.Delete(id);
    }

    #endregion
}