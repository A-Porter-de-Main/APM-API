using APMApi.Helpers;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestDto.RequestDto;
using APMApi.Services.MainRequests.RequestServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.RequestControllers;

[ApiController]
[Route("api/v{version:apiVersion}/requests")]
[ApiVersion("1.0")]
public class RequestController : ControllerBaseExtended<Request, RequestCreateDto, RequestUpdateDto, IRequestService>
{
    public RequestController(IRequestService service) : base(service)
    {
    }
}