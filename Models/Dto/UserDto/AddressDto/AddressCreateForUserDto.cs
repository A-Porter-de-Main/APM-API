using APMApi.Models.Database.UserModels;

namespace APMApi.Models.Dto.UserDto.AddressDto;

public class AddressCreateForUserDto : AddressCreateDto
{
    internal new Guid UserId { get; set; }
    public new string Street { get; set; } = null!;
    public new string City { get; set; } = null!;
    public new string ZipCode { get; set; } = null!;
    public new string Latitude { get; set; } = null!;
    public new string Longitude { get; set; } = null!;
    
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