using FluentValidation;

namespace APMApi.Models.Dto.UserModels.Role;

public class RoleCreateDto : IDataTransferObject
{
    public string Name { get; set; } = null!;
    
    private class Validator:AbstractValidator<RoleCreateDto>
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