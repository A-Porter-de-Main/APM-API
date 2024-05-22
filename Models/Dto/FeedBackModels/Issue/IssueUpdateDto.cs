using FluentValidation;

namespace APMApi.Models.Dto.FeedBackModels.Issue;

public class IssueUpdateDto : IDataTransferObject
{
    public string Description { get; set; } = null!;
    
    private class Validator:AbstractValidator<IssueUpdateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Description).NotEmpty().MaximumLength(250);
        }
    }
    
    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }
}