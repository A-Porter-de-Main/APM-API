using APMApi.Helpers;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestModels.Response;
using APMApi.Services.MainRequests.ResponseServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.Request;

[ApiController]
[Route("api/v{version:apiVersion}/responses")]
[ApiVersion("1.0")]
public class ResponsesController : ControllerBaseExtended<Response, ResponseCreateDto, ResponseUpdateDto, IResponseService>
{
    public ResponsesController(IResponseService service) : base(service) { }
}