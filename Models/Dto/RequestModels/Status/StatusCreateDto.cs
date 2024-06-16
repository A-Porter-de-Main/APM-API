using FluentValidation;

namespace APMApi.Models.Dto.RequestModels.Status;

public class StatusCreateDto : IDataTransferObject
{
    public string Name { get; set; } = null!;

    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<StatusCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Name).NotEmpty().MaximumLength(50);
        }
    }
}