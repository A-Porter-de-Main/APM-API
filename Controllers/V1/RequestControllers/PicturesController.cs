using APMApi.Helpers;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestModels.Picture;
using APMApi.Services.MainRequests.PictureServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.RequestControllers;

[ApiController]
[Route("api/v{version:apiVersion}/pictures")]
[ApiVersion("1.0")]
public class PicturesController : ControllerBaseExtended<Picture, PictureCreateDto, PictureUpdateDto, IPictureService>
{
    public PicturesController(IPictureService service) : base(service) { }
}