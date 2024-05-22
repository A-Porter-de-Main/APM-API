using APMApi.Helpers;
using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Dto.FeedBackModels.Issue;
using APMApi.Services.MainFeedBacks.IssueServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.FeedBack;

[ApiController]
[Route("api/v{version:apiVersion}/issues")]
[ApiVersion("1.0")]
public class IssuesController : ControllerBaseExtended<Issue, IssueCreateDto, IssueUpdateDto, IIssueService>
{
    public IssuesController(IIssueService service) : base(service) { }
}