using FluentValidation;

namespace APMApi.Models.Dto.RequestDto.ResponseStatusDto;

public class ResponseStatusCreateDto : IDataTransferObject
{
    public string Name { get; set; } = null!;

    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<ResponseStatusCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Name).NotEmpty().MaximumLength(50);
        }
    }
}