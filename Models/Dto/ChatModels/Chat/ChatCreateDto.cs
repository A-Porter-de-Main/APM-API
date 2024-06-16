using FluentValidation;

namespace APMApi.Models.Dto.ChatModels.Chat;

public class ChatCreateDto : IDataTransferObject
{
    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<ChatCreateDto>
    {
    }
}