using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserDto.RoleDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainUsers.RoleServices;

public interface IRoleService : IBaseService<Role, RoleCreateDto, RoleUpdateDto>
{
}