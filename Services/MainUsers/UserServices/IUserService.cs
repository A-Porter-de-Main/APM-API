using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserDto.UserDto;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainUsers.UserServices;

public interface IUserService : IBaseService<User, UserCreateDto, UserUpdateDto>
{
    public Task<TokenResponse?> Login(UserLoginDto userLoginDto);
    public TokenResponse GenerateVisitor();
}