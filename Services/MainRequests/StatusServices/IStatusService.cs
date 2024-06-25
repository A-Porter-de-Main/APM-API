using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestDto.StatusDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainRequests.StatusServices;

public interface IStatusService : IBaseService<Status, StatusCreateDto, StatusUpdateDto>
{
}