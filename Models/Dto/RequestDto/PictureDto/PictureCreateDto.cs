using FluentValidation;

namespace APMApi.Models.Dto.RequestDto.PictureDto;

public class PictureCreateDto : IDataTransferObject
{
    public string Path { get; set; } = null!;
    public string? Description { get; set; }

    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<PictureCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Path).NotEmpty().MaximumLength(250);
            RuleFor(s => s.Description).MaximumLength(250);
        }
    }
}