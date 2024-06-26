using FluentValidation;

namespace APMApi.Models.Dto.UserDto.AddressDto;

public class AddressCreateDto : IDataTransferObject
{
    public Guid UserId { get; set; }
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string Latitude { get; set; } = null!;
    public string Longitude { get; set; } = null!;

    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }

    private class Validator : AbstractValidator<AddressCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Street).NotEmpty().MaximumLength(50);
            RuleFor(s => s.City).NotEmpty().MaximumLength(85);
            RuleFor(s => s.ZipCode).NotEmpty().MaximumLength(50);
            RuleFor(s => s.Latitude).NotEmpty().MaximumLength(50);
            RuleFor(s => s.Longitude).NotEmpty().MaximumLength(50);
        }
    }
}