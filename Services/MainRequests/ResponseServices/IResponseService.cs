using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestDto.ResponseDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainRequests.ResponseServices;

public interface IResponseService : IBaseService<Response, ResponseCreateDto, ResponseUpdateDto>
{
    public Task<IEnumerable<Response>> GetAllScopedUser(Guid userId);
    public Task<IEnumerable<Response>> GetAllScopedRequest(Guid requestId);
}