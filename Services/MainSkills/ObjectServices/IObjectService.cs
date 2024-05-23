using APMApi.Models.Database.SkillModels;
using APMApi.Models.Dto.CategoryModels.Object;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainSkills.ObjectServices;

public interface IObjectService : IBaseService<ObjectModel, ObjectCreateDto, ObjectUpdateDto> { }