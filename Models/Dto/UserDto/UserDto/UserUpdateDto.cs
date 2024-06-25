using APMApi.Models.Dto.UserDto.AddressDto;
using FluentValidation;

namespace APMApi.Models.Dto.UserDto.UserDto;

public class UserUpdateDto : IDataTransferObject
{
    public string? FirstName { get; set; } = null!;
    public string? LastName { get; set; } = null!;
    public IFormFile? Image { get; set; } = null!;
    internal string? ImagePath { get; set; }
    public string? Email { get; set; } = null!;
    public string? Phone { get; set; } = null!;
    
    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<UserUpdateDto>
    {
        public Validator()
        {
            RuleFor(s => s.FirstName).MaximumLength(50);
            RuleFor(s => s.LastName).MaximumLength(50);
            RuleFor(s => s.Email).MaximumLength(250);
            RuleFor(s => s.Phone).MaximumLength(20);
        }
    }
}