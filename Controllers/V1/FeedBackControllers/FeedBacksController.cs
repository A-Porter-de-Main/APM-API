using APMApi.Helpers;
using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Dto.FeedBackModels.FeedBack;
using APMApi.Services.MainFeedBacks.FeedBackServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.FeedBackControllers;

[ApiController]
[Route("api/v{version:apiVersion}/feedbacks")]
[ApiVersion("1.0")]
public class
    FeedBacksController : ControllerBaseExtended<FeedBack, FeedBackCreateDto, FeedBackUpdateDto, IFeedBackService>
{
    public FeedBacksController(IFeedBackService service) : base(service)
    {
    }
}