using APMApi.Models;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestDto.ResponseStatusDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainRequests.ResponseStatusServices;

public class ResponseStatusService : BaseService<ResponseStatus, ResponseStatusCreateDto, ResponseStatusUpdateDto>,
    IResponseStatusService
{
    public ResponseStatusService(DataContext context) : base(context)
    {
    }
}