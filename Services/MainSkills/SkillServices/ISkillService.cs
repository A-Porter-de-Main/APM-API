using APMApi.Models.Database.SkillModels;
using APMApi.Models.Dto.CategoryDto.SkillDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainSkills.SkillServices;

public interface ISkillService : IBaseService<Skill, SkillCreateDto, SkillUpdateDto>
{
}