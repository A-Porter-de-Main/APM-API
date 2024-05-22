using APMApi.Models.Database.SkillModels;
using APMApi.Models.Dto.CategoryModels.Skill;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainSkills.SkillServices;

public class SkillService : BaseService<Skill, SkillCreateDto, SkillUpdateDto>, ISkillService
{
    protected SkillService(DataContext context) : base(context) { }
}