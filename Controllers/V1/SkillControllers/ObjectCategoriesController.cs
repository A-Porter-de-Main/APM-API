using APMApi.Helpers;
using APMApi.Models.Database.SkillModels;
using APMApi.Models.Dto.CategoryDto.TypeDto;
using APMApi.Services.MainSkills.ObjectCategoryServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.SkillControllers;

[ApiController]
[Route("api/v{version:apiVersion}/objects/categories")]
[ApiVersion("1.0")]
public class ObjectCategoriesController : ControllerBaseExtended<ObjectCategory, ObjectCategoryCreateDto,
    ObjectCategoryUpdateDto, IObjectCategoryService>
{
    public ObjectCategoriesController(IObjectCategoryService service) : base(service)
    {
    }
}