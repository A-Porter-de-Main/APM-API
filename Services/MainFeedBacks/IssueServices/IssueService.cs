using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserModels.Role;
using APMApi.Models.Other;
using APMApi.Services.MainUsers.RoleServices;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainFeedBacks.IssueServices;

public class IssueService : BaseService<Role, RoleCreateDto, RoleUpdateDto>, IRoleService
{
    protected IssueService(DataContext context) : base(context) { }
    
    
}