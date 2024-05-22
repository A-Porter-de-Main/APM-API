using FluentValidation;

namespace APMApi.Models.Dto.CategoryModels.Skill;

public class SkillCreateDto : IDataTransferObject
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    private class Validator:AbstractValidator<SkillCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Name).NotEmpty().MaximumLength(50);
            RuleFor(s => s.Description).NotEmpty().MaximumLength(250);
        }
    }
    
    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }
}