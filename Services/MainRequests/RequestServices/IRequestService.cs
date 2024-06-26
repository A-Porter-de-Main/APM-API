using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestDto.RequestDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainRequests.RequestServices;

public interface IRequestService : IBaseService<Request, RequestCreateDto, RequestUpdateDto>
{
    public Task<IEnumerable<Request>> GetAllScopedUser(Guid userId);
}