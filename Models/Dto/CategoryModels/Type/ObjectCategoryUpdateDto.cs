using FluentValidation;

namespace APMApi.Models.Dto.CategoryModels.Type;

public class ObjectCategoryUpdateDto : IDataTransferObject
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    private class Validator:AbstractValidator<ObjectCategoryUpdateDto>
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