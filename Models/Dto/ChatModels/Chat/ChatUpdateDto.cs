using FluentValidation;

namespace APMApi.Models.Dto.ChatModels.Chat;

public class ChatUpdateDto : IDataTransferObject
{
    private class Validator:AbstractValidator<ChatUpdateDto>
    {
        public Validator()
        {
            
        }
    }
    
    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }
}