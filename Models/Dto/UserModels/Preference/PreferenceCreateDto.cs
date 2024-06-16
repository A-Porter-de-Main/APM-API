using FluentValidation;

namespace APMApi.Models.Dto.UserModels.Preference;

public class PreferenceCreateDto : IDataTransferObject
{
    public bool ByMail { get; set; }
    public bool ByNotifications { get; set; }
    public bool ByPhone { get; set; }

    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<PreferenceCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.ByMail).NotEmpty();
            RuleFor(s => s.ByNotifications).NotEmpty();
            RuleFor(s => s.ByPhone).NotEmpty();
        }
    }
}