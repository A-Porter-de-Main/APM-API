using FluentValidation;

namespace APMApi.Models.Dto.RequestModels.Request;

public class RequestUpdateDto : IDataTransferObject
{
    public string Description { get; set; } = null!;
    public DateTime Deadline { get; set; }
    public Guid? PictureId { get; set; }

    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<RequestUpdateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Description).NotEmpty().MaximumLength(500);
            RuleFor(s => s.Deadline).NotEmpty();
            RuleFor(s => s.PictureId).NotEmpty();
        }
    }
}