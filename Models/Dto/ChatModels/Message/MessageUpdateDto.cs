using FluentValidation;

namespace APMApi.Models.Dto.ChatModels.Message;

public class MessageUpdateDto : IDataTransferObject
{
    public string Content { get; set; } = null!;
    
    private class Validator:AbstractValidator<MessageUpdateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Content).NotEmpty().MaximumLength(250);
        }
    }
    
    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }
}