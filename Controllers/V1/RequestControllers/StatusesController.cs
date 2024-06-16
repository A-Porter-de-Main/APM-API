using APMApi.Helpers;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestModels.Status;
using APMApi.Services.MainRequests.StatusServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.RequestControllers;

[ApiController]
[Route("api/v{version:apiVersion}/statuses")]
[ApiVersion("1.0")]
public class StatusesController : ControllerBaseExtended<Status, StatusCreateDto, StatusUpdateDto, IStatusService>
{
    public StatusesController(IStatusService service) : base(service)
    {
    }
}