using APMApi.Models;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestDto.ResponseDto;
using APMApi.Services.Other.BaseServices;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Services.MainRequests.ResponseServices;

public class ResponseService : BaseService<Response, ResponseCreateDto, ResponseUpdateDto>, IResponseService
{
    #region Fields

    private readonly DataContext _context;
    
    #endregion

    #region Constructor

    public ResponseService(DataContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<IEnumerable<Response>> GetAllScopedUser(Guid userId)
    {
        return await _context.Responses.Where(r => r.UserId == userId).ToListAsync();
    }

    public async Task<IEnumerable<Response>> GetAllScopedRequest(Guid requestId)
    {
        return await _context.Responses.Where(r => r.RequestId == requestId).ToListAsync();
    }

    #endregion
}