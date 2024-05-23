using APMApi.Helpers;
using APMApi.Models.Dto.RequestModels.Request;
using APMApi.Services.MainRequests.RequestServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.RequestControllers;

[ApiController]
[Route("api/v{version:apiVersion}/requests")]
[ApiVersion("1.0")]
public class RequestController : ControllerBaseExtended<Models.Database.RequestModels.Request, RequestCreateDto, RequestUpdateDto, IRequestService>
{
    public RequestController(IRequestService service) : base(service) { }
}