using APMApi.Models.Database.UserModels;
using APMApi.Models.Dto.UserModels.Preference;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainUsers.PreferenceServices;

public class PreferenceService : BaseService<Preference, PreferenceCreateDto, PreferenceUpdateDto>, IPreferenceService
{
    protected PreferenceService(DataContext context) : base(context) { }
    
    
}