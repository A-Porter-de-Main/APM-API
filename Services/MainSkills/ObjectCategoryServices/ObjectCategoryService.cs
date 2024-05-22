using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserModels.Role;
using APMApi.Models.Other;
using APMApi.Services.MainUsers.RoleServices;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainSkills.ObjectCategoryServices;

public class ObjectCategoryService : BaseService<Role, RoleCreateDto, RoleUpdateDto>, IRoleService
{
    protected ObjectCategoryService(DataContext context) : base(context) { }
    
    
}