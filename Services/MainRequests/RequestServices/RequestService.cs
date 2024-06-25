using APMApi.Models;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestDto.RequestDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainRequests.RequestServices;

public class RequestService : BaseService<Request, RequestCreateDto, RequestUpdateDto>, IRequestService
{
    public RequestService(DataContext context) : base(context)
    {
    }
}