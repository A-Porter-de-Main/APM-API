using APMApi.Models;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestDto.StatusDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainRequests.StatusServices;

public class StatusService : BaseService<Status, StatusCreateDto, StatusUpdateDto>, IStatusService
{
    public StatusService(DataContext context) : base(context)
    {
    }
}