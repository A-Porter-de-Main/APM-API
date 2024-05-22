using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserModels.Role;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainUsers.RoleServices;

public interface IRoleService : IBaseService<Role, RoleCreateDto, RoleUpdateDto> { }