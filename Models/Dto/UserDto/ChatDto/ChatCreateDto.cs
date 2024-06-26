using FluentValidation;

namespace APMApi.Models.Dto.UserDto.ChatDto;

public class ChatCreateDto : IDataTransferObject
{
    public Guid ResponseId { get; set; }
    
    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<ChatCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.ResponseId).NotEmpty();
        }
    }
}