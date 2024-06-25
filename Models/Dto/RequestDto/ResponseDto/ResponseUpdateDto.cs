using FluentValidation;

namespace APMApi.Models.Dto.RequestDto.ResponseDto;

public class ResponseUpdateDto : IDataTransferObject
{
    public string Description { get; set; } = null!;
    public Guid RequestId { get; set; }
    public Guid UserId { get; set; }

    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<ResponseUpdateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Description).NotEmpty().MaximumLength(250);
            RuleFor(s => s.RequestId).NotEmpty();
            RuleFor(s => s.UserId).NotEmpty();
        }
    }
}