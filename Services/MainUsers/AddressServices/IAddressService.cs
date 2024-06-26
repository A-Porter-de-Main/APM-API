using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserDto.AddressDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainUsers.AddressServices;

public interface IAddressService : IBaseService<Address, AddressCreateDto, AddressUpdateDto>
{
}