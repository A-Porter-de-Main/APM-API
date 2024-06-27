using APMApi.Helpers;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserDto.UserDto;
using APMApi.Models.Exception;
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

    public UserController(
        IUserService userService,
        IFileService fileService
    ) : base(userService) {
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
            var id = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (User.Identity?.IsAuthenticated == true && id != null)
            {
                var user = await _userService.GetById(Guid.Parse(id));
                if (user != null)
                {
                    var token = _userService.GenerateToken(user);
                    if (token == null) throw new Exception("Impossible to login");
                    HttpContext.Response.Cookies.Append("dXNlclRva2Vu", token.Token);
                    
                    user.PicturePath = _fileService.GetRightUrl(HttpContext.Request, user.PicturePath);
                    return new { token, user };
                }
            }

            var visitorToken = _userService.GenerateToken();
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
            
            var visitorToken = _userService.GenerateToken();
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
            
            await ValidateDto(createDto);
            var user = await _userService.Create(createDto);
            
            var token = _userService.GenerateToken(user);
            if (token == null) throw new Exception("Impossible to login");
            HttpContext.Response.Cookies.Append("dXNlclRva2Vu", token.Token);
            
            user.PicturePath = _fileService.GetRightUrl(HttpContext.Request, user.PicturePath);

            return user;
        });
    }

    [HttpPut("self")]
    [Authorize("user")]
    public Task<IActionResult> UpdateSelf(UserUpdateDto updateDto)
    {
        return TryExecuteControllerTask(async () =>
        {
            var id = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (User.Identity?.IsAuthenticated == false || id == null) throw new Exception("User is not authenticated");
            var user = await _userService.GetById(Guid.Parse(id));
            if (user == null) throw new NotFoundException("User not found");
            
            if (updateDto.Image != null) updateDto.ImagePath = await _fileService.UpdateDocument(updateDto.Image, user.PicturePath);
            await ValidateDto(updateDto);

            user.PicturePath = _fileService.GetRightUrl(HttpContext.Request, user.PicturePath);
            
            return await _userService.Update(Guid.Parse(id), updateDto);
        });
    }

    [HttpPut("{id:guid}")]
    [Authorize("admin")]
    public override Task<IActionResult> Update(Guid id, UserUpdateDto updateDto)
    {
        return TryExecuteControllerTask(async () =>
        {
            var user = await _userService.GetById(id);
            if (user == null) throw new NotFoundException("User not found");
            
            if (updateDto.Image != null) updateDto.ImagePath = await _fileService.UpdateDocument(updateDto.Image, user.PicturePath);
            await ValidateDto(updateDto);

            user.PicturePath = _fileService.GetRightUrl(HttpContext.Request, user.PicturePath);
            
            return await _userService.Update(id, updateDto);
        });
    }
    
    [HttpDelete("self")]
    [Authorize("user")]
    public Task<IActionResult> DeleteSelf()
    {
        return TryExecuteControllerTask(async () =>
        {
            var id = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (User.Identity?.IsAuthenticated == false || id == null) throw new Exception("User is not authenticated");
            var user = await _userService.GetById(Guid.Parse(id));
            if (user == null) throw new NotFoundException("User not found");

            HttpContext.Response.Cookies.Delete("dXNlclRva2Vu");
            
            _fileService.DeleteDocument(user.PicturePath);
            
            var visitorToken = _userService.GenerateToken();
            HttpContext.Response.Cookies.Append("dXNlclRva2Vu", visitorToken.Token);
            return Task.FromResult(visitorToken);
        });
    }

    [HttpDelete("{id:guid}")]
    [Authorize("admin")]
    public override Task<IActionResult> Delete(Guid id)
    {
        return TryExecuteControllerTask(async () =>
        {
            var user = await _userService.GetById(id);
            if (user == null) throw new NotFoundException("User not found");

            _fileService.DeleteDocument(user.PicturePath);
            return await _userService.Delete(id);
        });
    }

    #endregion
}