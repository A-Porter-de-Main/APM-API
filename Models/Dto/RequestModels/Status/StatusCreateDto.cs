using FluentValidation;

namespace APMApi.Models.Dto.RequestModels.Status;

public class StatusCreateDto : IDataTransferObject
{
    public string Name { get; set; } = null!;
    
    private class Validator:AbstractValidator<StatusCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Name).NotEmpty().MaximumLength(50);
        }
    }
    
    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }
}