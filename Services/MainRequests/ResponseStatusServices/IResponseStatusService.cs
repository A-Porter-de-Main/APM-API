using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestDto.ResponseStatusDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainRequests.ResponseStatusServices;

public interface IResponseStatusService : IBaseService<ResponseStatus, ResponseStatusCreateDto, ResponseStatusUpdateDto>
{
}