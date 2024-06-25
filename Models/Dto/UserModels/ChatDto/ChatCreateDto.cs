using FluentValidation;

namespace APMApi.Models.Dto.UserModels.ChatDto;

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