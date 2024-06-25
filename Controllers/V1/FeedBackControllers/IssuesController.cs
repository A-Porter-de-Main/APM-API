using APMApi.Helpers;
using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Dto.FeedBackDto.IssueDto;
using APMApi.Services.MainFeedBacks.IssueServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.FeedBackControllers;

[ApiController]
[Route("api/v{version:apiVersion}/issues")]
[ApiVersion("1.0")]
public class IssuesController : ControllerBaseExtended<Issue, IssueCreateDto, IssueUpdateDto, IIssueService>
{
    public IssuesController(IIssueService service) : base(service)
    {
    }
}