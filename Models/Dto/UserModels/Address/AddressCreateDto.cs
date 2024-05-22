using FluentValidation;

namespace APMApi.Models.Dto.UserModels.Address;

public class AddressCreateDto : IDataTransferObject
{
    public string Street { get; set; } = null!;
    public string? Floor { get; set; }
    public string City { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string Latitude { get; set; } = null!;
    public string Longitude { get; set; } = null!;
    
    private class Validator:AbstractValidator<AddressCreateDto>
    {
        public Validator()
        {
            RuleFor(s => s.Street).NotEmpty().MaximumLength(50);
            RuleFor(s => s.Floor).MaximumLength(50);
            RuleFor(s => s.City).NotEmpty().MaximumLength(85);
            RuleFor(s => s.ZipCode).NotEmpty().MaximumLength(50);
            RuleFor(s => s.Latitude).NotEmpty().MaximumLength(50);
            RuleFor(s => s.Longitude).NotEmpty().MaximumLength(50);
        }
    }
    
    public async Task Validate()
    {
        var validator = new Validator();
        await validator.ValidateAndThrowAsync(this);
    }
}