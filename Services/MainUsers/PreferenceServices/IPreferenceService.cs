using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserDto.PreferenceDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainUsers.PreferenceServices;

public interface IPreferenceService : IBaseService<Preference, PreferenceCreateDto, PreferenceUpdateDto>
{
}