using APMApi.Helpers;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserModels.PreferenceDto;
using APMApi.Services.MainUsers.PreferenceServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.UserControllers;

[ApiController]
[Route("api/v{version:apiVersion}/preferences")]
[ApiVersion("1.0")]
public class PreferencesController : ControllerBaseExtended<Preference, PreferenceCreateDto, PreferenceUpdateDto,
    IPreferenceService>
{
    public PreferencesController(IPreferenceService service) : base(service)
    {
    }
}