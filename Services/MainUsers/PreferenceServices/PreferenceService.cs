using APMApi.Context;
using APMApi.Models;
using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserModels.PreferenceDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainUsers.PreferenceServices;

public class PreferenceService : BaseService<Preference, PreferenceCreateDto, PreferenceUpdateDto>, IPreferenceService
{
    public PreferenceService(DataContext context) : base(context)
    {
    }
}