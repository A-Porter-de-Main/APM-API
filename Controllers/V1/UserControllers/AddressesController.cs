using APMApi.Helpers;
using APMApi.Models.Database;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.FeedBackModels.FeedBack;
using APMApi.Models.Dto.UserModels.Address;
using APMApi.Services.MainUsers.AddressServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.User;

[ApiController]
[Route("api/v{version:apiVersion}/addresses")]
[ApiVersion("1.0")]
public class AddressesController : ControllerBaseExtended<Address, AddressCreateDto, AddressUpdateDto, IAddressService>
{
    public AddressesController(IAddressService service) : base(service) { }
}