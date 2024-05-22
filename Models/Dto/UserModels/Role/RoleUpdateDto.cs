using FluentValidation;

namespace APMApi.Models.Dto.UserModels.Role;

public class RoleUpdateDto : IDataTransferObject
{
    public string Name { get; set; } = null!;

    
    private class Validator:AbstractValidator<RoleUpdateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Name).NotEmpty().MaximumLength(50);
        }
    }
    
    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }
}