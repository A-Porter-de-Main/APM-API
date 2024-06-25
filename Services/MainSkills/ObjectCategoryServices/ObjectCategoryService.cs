using APMApi.Context;
using APMApi.Models;
using APMApi.Models.Database.SkillModels;
using APMApi.Models.Dto.CategoryDto.TypeDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainSkills.ObjectCategoryServices;

public class ObjectCategoryService : BaseService<ObjectCategory, ObjectCategoryCreateDto, ObjectCategoryUpdateDto>,
    IObjectCategoryService
{
    public ObjectCategoryService(DataContext context) : base(context)
    {
    }
}