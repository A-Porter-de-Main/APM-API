using APMApi.Models.Database.SkillModels;
using APMApi.Models.Dto.CategoryModels.Object;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;
using APMApi.Services.Skills.ObjectServices;

namespace APMApi.Services.MainSkills.ObjectServices;

public class ObjectService : BaseService<ObjectModel, ObjectCreateDto, ObjectUpdateDto>, IObjectService
{
    protected ObjectService(DataContext context) : base(context) { }
    
    
}