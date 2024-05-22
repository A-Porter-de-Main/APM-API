using APMApi.Models.Dto.UserModels.User;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainUsers.UserServices;

public interface IUserService : IBaseService<Models.Database.UserModels.User, UserCreateDto, UserUpdateDto>
{
    public Task<TokenResponse?> Login(UserLoginDto userLoginDto);
}