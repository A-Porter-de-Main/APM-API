using APMApi.Helpers;
using APMApi.Models.Database.SkillModels;
using APMApi.Models.Dto.CategoryModels.Object;
using APMApi.Services.Skills.ObjectServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.Skill;

[ApiController]
[Route("api/v{version:apiVersion}/objects")]
[ApiVersion("1.0")]
public class ObjectsController : ControllerBaseExtended<ObjectModel, ObjectCreateDto, ObjectUpdateDto, IObjectService>
{
    public ObjectsController(IObjectService service) : base(service) { }
}