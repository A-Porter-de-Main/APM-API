using FluentValidation;

namespace APMApi.Models.Dto.ChatModels.Chat;

public class ChatCreateDto : IDataTransferObject
{
    
    private class Validator:AbstractValidator<ChatCreateDto>
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