using APMApi.Models.Database.SkillModels;
using APMApi.Models.Dto.CategoryModels.Type;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainSkills.ObjectCategoryServices;

public class ObjectCategoryService : BaseService<ObjectCategory, ObjectCategoryCreateDto, ObjectCategoryUpdateDto>, IObjectCategoryService
{
    public ObjectCategoryService(DataContext context) : base(context) { }
    
    
}