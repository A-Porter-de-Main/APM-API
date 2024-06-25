using APMApi.Models.Database.SkillModels;
using APMApi.Models.Dto.CategoryDto.ObjectDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainSkills.ObjectServices;

public interface IObjectService : IBaseService<ObjectModel, ObjectCreateDto, ObjectUpdateDto>
{
}