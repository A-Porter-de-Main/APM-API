using APMApi.Models.Database;
using FluentValidation;

namespace APMApi.Models.Dto.RequestDto.RequestDto;

public class RequestUpdateDto : IDataTransferObject
{
    public string? Title { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public DateTime? Deadline { get; set; }
    public IEnumerable<IFormFile>? Pictures { get; set; } = null!;
    internal IEnumerable<Picture>? PicturesCreated { get; set; }
    public IEnumerable<Guid>? Skills { get; set; } = null!;

    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<RequestUpdateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Title).MaximumLength(50);
            RuleFor(s => s.Description).MaximumLength(500);
            RuleFor(s => s.PicturesCreated);
            RuleFor(s => s.Skills);
            RuleFor(s => s.Deadline);
        }
    }
}