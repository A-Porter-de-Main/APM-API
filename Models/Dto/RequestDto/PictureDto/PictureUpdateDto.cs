using FluentValidation;

namespace APMApi.Models.Dto.RequestDto.PictureDto;

public class PictureUpdateDto : IDataTransferObject
{
    public string Path { get; set; } = null!;
    public string? Description { get; set; }

    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<PictureUpdateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Path).NotEmpty().MaximumLength(250);
            RuleFor(s => s.Description).MaximumLength(250);
        }
    }
}