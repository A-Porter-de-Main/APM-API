using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserModels.Role;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainUsers.RoleServices;

public class RoleService : BaseService<Role, RoleCreateDto, RoleUpdateDto>, IRoleService
{
    public RoleService(DataContext context) : base(context)
    {
    }
}