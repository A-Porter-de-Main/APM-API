using FluentValidation;

namespace APMApi.Models.Dto.FeedBackModels.FeedBack;

public class FeedBackUpdateDto : IDataTransferObject {
    public string Description { get; set; } = null!;
    public int Note { get; set; }
    
    private class Validator:AbstractValidator<FeedBackUpdateDto>
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