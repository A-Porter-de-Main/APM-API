using FluentValidation;

namespace APMApi.Models.Dto.UserDto.RoleDto;

public class RoleCreateDto : IDataTransferObject
{
    public string Name { get; set; } = null!;

    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<RoleCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Name).NotEmpty().MaximumLength(50);
        }
    }
}