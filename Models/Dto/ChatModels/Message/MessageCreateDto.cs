using FluentValidation;

namespace APMApi.Models.Dto.ChatModels.Message;

public class MessageCreateDto : IDataTransferObject
{
    public string Content { get; set; } = null!;
    public Guid ChatId { get; set; }
    public Guid UserId { get; set; }
    
    private class Validator:AbstractValidator<MessageCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Content).NotEmpty().MaximumLength(250);
            RuleFor(s => s.ChatId).NotEmpty();
            RuleFor(s => s.UserId).NotEmpty();
        }
    }
    
    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }
}