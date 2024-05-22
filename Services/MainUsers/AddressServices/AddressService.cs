using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserModels.Address;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainUsers.AddressServices;

public class AddressService : BaseService<Address, AddressCreateDto, AddressUpdateDto>, IAddressService
{
    protected AddressService(DataContext context) : base(context) { }
    
    
}