using FluentValidation;

namespace APMApi.Models.Dto.RequestModels.Picture;

public class PictureCreateDto : IDataTransferObject
{
    public string Path { get; set; } = null!;
    public string? Description { get; set; }
    
    private class Validator:AbstractValidator<PictureCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Path).NotEmpty().MaximumLength(250);
            RuleFor(s => s.Description).MaximumLength(250);
        }
    }
    
    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }
}