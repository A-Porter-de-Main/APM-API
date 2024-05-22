using APMApi.Helpers;
using APMApi.Models.Database;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserModels.Preference;
using APMApi.Services.MainUsers.PreferenceServices;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APMApi.Controllers.V1.User;

[ApiController]
[Route("api/v{version:apiVersion}/preferences")]
[ApiVersion("1.0")]
public class PreferencesController : ControllerBaseExtended<Preference, PreferenceCreateDto, PreferenceUpdateDto, IPreferenceService>
{
    public PreferencesController(IPreferenceService service) : base(service) { }
}