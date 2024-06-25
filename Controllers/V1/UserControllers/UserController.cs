using APMApi.Helpers;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserDto.UserDto;
using APMApi.Services.MainUsers.UserServices;
using APMApi.Services.Other.FileServices;
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
    private readonly IFileService _fileService;

    #endregion

    #region Constructor

    public UserController(IUserService userService, IFileService fileService) : base(userService)
    {
        _userService = userService;
        _fileService = fileService;
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
            
            var visitorToken = _userService.GenerateVisitor();
            HttpContext.Response.Cookies.Append("dXNlclRva2Vu", visitorToken.Token);
            return Task.FromResult(visitorToken);
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
    public override Task<IActionResult> Create([FromForm] UserCreateDto createDto)
    {
        return TryExecuteControllerTask(async () =>
        {
            if (createDto.Image == null) throw new Exception("Image is required");
            createDto.ImagePath = await _fileService.AddDocument(createDto.Image);
            
            var password = createDto.Password;
            await ValidateDto(createDto);
            var result = await _userService.Create(createDto);
            var token = await _userService.Login(new UserLoginDto
            {
                Email = createDto.Email,
                Password = password
            });
            if (token == null) throw new Exception("Impossible to login");
            HttpContext.Response.Cookies.Append("dXNlclRva2Vu", token.Token);
            return result;
        });
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