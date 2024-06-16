using FluentValidation;

namespace APMApi.Models.Dto.FeedBackModels.Issue;

public class IssueCreateDto : IDataTransferObject
{
    public string Description { get; set; } = null!;

    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<IssueCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Description).NotEmpty().MaximumLength(250);
        }
    }
}