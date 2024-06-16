using FluentValidation;

namespace APMApi.Models.Dto.ChatModels.Message;

public class MessageUpdateDto : IDataTransferObject
{
    public string Content { get; set; } = null!;

    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<MessageUpdateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Content).NotEmpty().MaximumLength(250);
        }
    }
}