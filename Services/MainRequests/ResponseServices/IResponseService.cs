using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestModels.Response;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainRequests.ResponseServices;

public interface IResponseService : IBaseService<Response, ResponseCreateDto, ResponseUpdateDto>
{
}