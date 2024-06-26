using APMApi.Models.Database;
using FluentValidation;

namespace APMApi.Models.Dto.RequestDto.RequestDto;

public class RequestCreateDto : IDataTransferObject
{
    internal Guid UserId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public IEnumerable<IFormFile> Pictures { get; set; } = null!;
    internal IEnumerable<Picture>? PicturesCreated { get; set; }
    public IEnumerable<Guid> Skills { get; set; } = null!;
    public DateTime Deadline { get; set; }

    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<RequestCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.UserId).NotEmpty();
            RuleFor(s => s.Title).NotEmpty().MaximumLength(50);
            RuleFor(s => s.Description).NotEmpty().MaximumLength(500);
            RuleFor(s => s.PicturesCreated).NotEmpty();
            RuleFor(s => s.Skills).NotEmpty();
            RuleFor(s => s.Deadline).NotEmpty();
        }
    }
}