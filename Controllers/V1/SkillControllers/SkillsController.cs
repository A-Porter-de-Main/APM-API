using APMApi.Helpers;
using APMApi.Models.Dto.CategoryModels.Skill;
using APMApi.Services.MainSkills.SkillServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.SkillControllers;

[ApiController]
[Route("api/v{version:apiVersion}/skills")]
[ApiVersion("1.0")]
public class SkillsController : ControllerBaseExtended<Models.Database.SkillModels.Skill, SkillCreateDto, SkillUpdateDto, ISkillService>
{
    public SkillsController(ISkillService service) : base(service) { }
}