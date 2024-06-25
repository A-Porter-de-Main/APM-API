using APMApi.Helpers;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestDto.StatusDto;
using APMApi.Services.MainRequests.StatusServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.RequestControllers;

[ApiController]
[Route("api/v{version:apiVersion}/response-statuses")]
[ApiVersion("1.0")]
public class ResponseStatusesController : ControllerBaseExtended<Status, StatusCreateDto, StatusUpdateDto, IStatusService>
{
    public ResponseStatusesController(IStatusService service) : base(service)
    {
    }
}