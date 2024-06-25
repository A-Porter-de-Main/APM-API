using FluentValidation;

namespace APMApi.Models.Dto.FeedBackDto.IssueDto;

public class IssueUpdateDto : IDataTransferObject
{
    public string Description { get; set; } = null!;

    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<IssueUpdateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Description).NotEmpty().MaximumLength(250);
        }
    }
}