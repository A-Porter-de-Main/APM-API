using APMApi.Models.Dto.FeedBackModels.FeedBack;
using FluentValidation;

namespace APMApi.Models.Dto.RequestModels.Response;

public class ResponseCreateDto : IDataTransferObject
{
    public string Description { get; set; } = null!;
    public Guid RequestId { get; set; }
    public Guid UserId { get; set; }
    
    private class Validator:AbstractValidator<ResponseCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Description).NotEmpty().MaximumLength(250);
            RuleFor(s => s.RequestId).NotEmpty();
            RuleFor(s => s.UserId).NotEmpty();
        }
    }
    
    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }
}