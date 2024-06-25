using APMApi.Context;
using APMApi.Models;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestDto.ResponseDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainRequests.ResponseServices;

public class ResponseService : BaseService<Response, ResponseCreateDto, ResponseUpdateDto>, IResponseService
{
    public ResponseService(DataContext context) : base(context)
    {
    }
}