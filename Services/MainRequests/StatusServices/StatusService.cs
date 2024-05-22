using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestModels.Status;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainRequests.StatusServices;

public class StatusService : BaseService<Status, StatusCreateDto, StatusUpdateDto>, IStatusService
{
    protected StatusService(DataContext context) : base(context) { }
    
    
}