using FluentValidation;

namespace APMApi.Models.Dto.UserModels.User;

public class UserUpdateDto : IDataTransferObject
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    
    private class Validator:AbstractValidator<UserUpdateDto>
    {
        public Validator()
        {
            RuleFor(s => s.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(s => s.LastName).NotEmpty().MaximumLength(50);
            RuleFor(s => s.Email).NotEmpty().MaximumLength(250);
            RuleFor(s => s.Phone).NotEmpty().MaximumLength(20);
        }
    }
    
    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }
}