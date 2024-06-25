using FluentValidation;

namespace APMApi.Models.Dto.RequestDto.ResponseStatusDto;

public class ResponseStatusUpdateDto : IDataTransferObject
{
    public string Name { get; set; } = null!;

    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<ResponseStatusUpdateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Name).NotEmpty().MaximumLength(50);
        }
    }
}