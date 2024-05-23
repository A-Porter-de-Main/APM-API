using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestModels.Request;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainRequests.RequestServices;

public class RequestService : BaseService<Request, RequestCreateDto, RequestUpdateDto>, IRequestService
{
    public RequestService(DataContext context) : base(context) { }
    
    
}