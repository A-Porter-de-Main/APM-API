using APMApi.Models;
using APMApi.Models.Database.SkillModels;
using APMApi.Models.Dto.CategoryDto.SkillDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainSkills.SkillServices;

public class SkillService : BaseService<Skill, SkillCreateDto, SkillUpdateDto>, ISkillService
{
    public SkillService(DataContext context) : base(context)
    {
    }
}