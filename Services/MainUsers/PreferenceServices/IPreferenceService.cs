using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserModels.Preference;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainUsers.PreferenceServices;

public interface IPreferenceService : IBaseService<Preference, PreferenceCreateDto, PreferenceUpdateDto>
{
}