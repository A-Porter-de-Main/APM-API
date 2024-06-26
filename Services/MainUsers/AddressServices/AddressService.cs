using APMApi.Models;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserDto.AddressDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainUsers.AddressServices;

public class AddressService : BaseService<Address, AddressCreateDto, AddressUpdateDto>, IAddressService
{
    public AddressService(DataContext context) : base(context)
    {
    }
}