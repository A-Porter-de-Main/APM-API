using APMApi.Models.Database.SkillModels;
using APMApi.Models.Dto.CategoryModels.Type;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainSkills.ObjectCategoryServices;

public interface IObjectCategoryService : IBaseService<ObjectCategory, ObjectCategoryCreateDto, ObjectCategoryUpdateDto>
{
}