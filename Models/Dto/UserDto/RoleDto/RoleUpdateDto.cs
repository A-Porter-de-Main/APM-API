using FluentValidation;

namespace APMApi.Models.Dto.UserDto.RoleDto;

public class RoleUpdateDto : IDataTransferObject
{
    public string Name { get; set; } = null!;

    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }


    private class Validator : AbstractValidator<RoleUpdateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Name).NotEmpty().MaximumLength(50);
        }
    }
}