using APMApi.Models.Database.SkillModels;
using APMApi.Models.Dto.CategoryModels.Object;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainSkills.ObjectServices;

public class ObjectService : BaseService<ObjectModel, ObjectCreateDto, ObjectUpdateDto>, IObjectService
{
    public ObjectService(DataContext context) : base(context)
    {
    }
}