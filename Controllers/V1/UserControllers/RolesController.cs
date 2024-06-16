using APMApi.Helpers;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserModels.Role;
using APMApi.Services.MainUsers.RoleServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.UserControllers;

[ApiController]
[Route("api/v{version:apiVersion}/roles")]
[ApiVersion("1.0")]
public class RolesController : ControllerBaseExtended<Role, RoleCreateDto, RoleUpdateDto, IRoleService>
{
    public RolesController(IRoleService service) : base(service)
    {
    }
}