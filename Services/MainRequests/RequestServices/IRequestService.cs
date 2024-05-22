using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestModels.Request;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainRequests.RequestServices;

public interface IRequestService : IBaseService<Request, RequestCreateDto, RequestUpdateDto> { }