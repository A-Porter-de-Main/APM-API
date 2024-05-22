using FluentValidation;

namespace APMApi.Models.Dto.FeedBackModels.FeedBackApplication;

public class FeedBackApplicationCreateDto : IDataTransferObject
{
    public string Description { get; set; } = null!;
    public int Note { get; set; }
    
    private class Validator:AbstractValidator<FeedBackApplicationCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Description).NotEmpty().MaximumLength(500);
            RuleFor(s => s.Note).InclusiveBetween(1, 10);
        }
    }
    
    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }
}