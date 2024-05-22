using FluentValidation;

namespace APMApi.Models.Dto.UserModels.User;

public class UserLoginDto : IDataTransferObject
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    
    private class Validator:AbstractValidator<UserLoginDto>
    {
        public Validator()
        {
            RuleFor(s => s.Email).NotEmpty().MaximumLength(50);
            RuleFor(s => s.Password).NotEmpty().MaximumLength(50);
        }
    }
    
    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }
}