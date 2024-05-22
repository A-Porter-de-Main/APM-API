using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APMApi.Models.Dto.UserModels.User;
using APMApi.Models.Exception;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace APMApi.Services.MainUsers.UserServices;

public class UserService : BaseService<Models.Database.UserModels.User, UserCreateDto, UserUpdateDto>, IUserService
{
    #region MyRegion

    private readonly DataContext _context;
    private readonly IConfiguration _config;

    #endregion

    #region MyRegion

    public UserService(DataContext context, IConfiguration configuration) : base(context)
    {
        _context = context;
        _config = configuration;
    }

    #endregion

    #region Methods

    public override async Task<Models.Database.UserModels.User> Create(UserCreateDto createDto)
    {
        createDto.Password = BCrypt.Net.BCrypt.HashPassword(createDto.Password, 5);
        return await base.Create(createDto);
    }

    public async Task<TokenResponse?> Login(UserLoginDto userLoginDto)
    {
        var superUser = await _context.Users.FirstOrDefaultAsync(su => su.Email == userLoginDto.Email);
        if (superUser == null) throw new NotFoundException("Super User not found");
        
        if (!BCrypt.Net.BCrypt.Verify(userLoginDto.Password, superUser.Password)) throw new Exception("Invalid password");
        
        var key = _config.GetSection("Jwt:Key").Get<string>() ?? throw new Exception("Jwt:Key not found in appsettings.json");
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        var claims = new[]
        {
            new Claim("id", superUser.Id.ToString()),
            new Claim("name", superUser.Email),
        };
        
        var token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials
        );
        
        return new TokenResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expires = token.ValidTo
        };
    }

    #endregion
}