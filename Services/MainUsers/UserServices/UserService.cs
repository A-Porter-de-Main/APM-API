using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APMApi.Models;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserDto.UserDto;
using APMApi.Models.Exception;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace APMApi.Services.MainUsers.UserServices;

public class UserService : BaseService<User, UserCreateDto, UserUpdateDto>, IUserService
{
    #region Constructor

    public UserService(DataContext context, IConfiguration configuration) : base(context)
    {
        _context = context;
        _config = configuration;
    }

    #endregion

    #region MyRegion

    private readonly DataContext _context;
    private readonly IConfiguration _config;

    #endregion

    #region Methods

    public override async Task<User> Create(UserCreateDto createDto)
    {
        createDto.Password = BCrypt.Net.BCrypt.HashPassword(createDto.Password, 5);
        var role = await _context.Roles.FirstOrDefaultAsync(s => s.Name == "user");

        var result = await _context.Users.AddAsync(new User
        {
            FirstName = createDto.FirstName,
            LastName = createDto.LastName,
            Email = createDto.Email,
            Phone = createDto.Phone,
            Password = createDto.Password,
            PicturePath = createDto.ImagePath ?? "",
            RoleId = role?.Id,
            Role = role?.Id == null ? new Role
            {
                Name = "user"
            } : null,
            Addresses = createDto.Address != null
                ? new[]
                {
                    createDto.Address.ConvertToAddress()
                }
                : null,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        });
        
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<TokenResponse?> Login(UserLoginDto userLoginDto)
    {
        var user = await _context.Users.Include(s => s.Role).FirstOrDefaultAsync(su => su.Email == userLoginDto.Email);
        if (user == null) throw new NotFoundException("User not found");

        if (!BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password)) throw new Exception("Invalid password");

        return GenerateToken(user);
    }

    public TokenResponse GenerateToken(User? user = null)
    {
        if (user is { Role: null }) throw new Exception("User role not found");
        
        var key = _config.GetSection("Jwt:Key").Get<string>() ??
                  throw new Exception("Jwt:Key not found in appsettings.json");
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = user == null ?
            new[]
            {
                new Claim("role", "visitor"),
                new Claim(ClaimTypes.Role, "visitor")
            } :
            new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim("name", user.Email),
                new Claim("role", user.Role.Name),
                new Claim(ClaimTypes.Role, user.Role.Name)
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

    public override async Task<User?> GetById(Guid id)
    {
        return await _context.Users
            .Include(s => s.Addresses)
            .Include(s => s.Preference)
            .Include(s => s.Skills)
            .Include(s => s.Role)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    #endregion
}