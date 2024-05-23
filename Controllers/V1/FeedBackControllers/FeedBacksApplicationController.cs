using APMApi.Helpers;
using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Dto.FeedBackModels.FeedBackApplication;
using APMApi.Services.MainFeedBacks.FeedBackApplicationServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.FeedBackControllers;

[ApiController]
[Route("api/v{version:apiVersion}/feedbacks/application")]
[ApiVersion("1.0")]
public class FeedBacksApplicationController : ControllerBaseExtended<FeedBackApplication, FeedBackApplicationCreateDto, FeedBackApplicationUpdateDto, IFeedBackApplicationService>
{
    public FeedBacksApplicationController(IFeedBackApplicationService service) : base(service) { }
}