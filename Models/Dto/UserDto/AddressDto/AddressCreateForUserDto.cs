using APMApi.Models.Database.UserModels;
using FluentValidation;

namespace APMApi.Models.Dto.UserDto.AddressDto;

public class AddressCreateForUserDto : AddressCreateDto
{
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string Latitude { get; set; } = null!;
    public string Longitude { get; set; } = null!;
    
    public Address ConvertToAddress()
    {
        return new Address
        {
            Street = Street,
            City = City,
            ZipCode = ZipCode,
            Latitude = Latitude,
            Longitude = Longitude
        };
    }
}