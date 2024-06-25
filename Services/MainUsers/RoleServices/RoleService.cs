using APMApi.Context;
using APMApi.Models;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserModels.RoleDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainUsers.RoleServices;

public class RoleService : BaseService<Role, RoleCreateDto, RoleUpdateDto>, IRoleService
{
    public RoleService(DataContext context) : base(context)
    {
    }
}