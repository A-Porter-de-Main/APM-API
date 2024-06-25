using FluentValidation;

namespace APMApi.Models.Dto.FeedBackDto.FeedBackDto;

public class FeedBackCreateDto : IDataTransferObject
{
    public string Description { get; set; } = null!;
    public int Note { get; set; }

    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<FeedBackCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Description).NotEmpty().MaximumLength(500);
            RuleFor(s => s.Note).InclusiveBetween(1, 10);
        }
    }
}