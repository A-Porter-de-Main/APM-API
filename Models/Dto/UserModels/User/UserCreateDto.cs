using FluentValidation;

namespace APMApi.Models.Dto.UserModels.User;

public class UserCreateDto : IDataTransferObject
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Password { get; set; } = null!;
    
    private class Validator:AbstractValidator<UserCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(s => s.LastName).NotEmpty().MaximumLength(50);
            RuleFor(s => s.Email).NotEmpty().MaximumLength(250);
            RuleFor(s => s.Phone).NotEmpty().MaximumLength(20);
            RuleFor(s => s.Password).NotEmpty().MaximumLength(250);
        }
    }
    
    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }
}