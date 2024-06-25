using APMApi.Context;
using APMApi.Models;
using APMApi.Models.Database;
using APMApi.Models.Dto.RequestDto.PictureDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainRequests.PictureServices;

public class PictureService : BaseService<Picture, PictureCreateDto, PictureUpdateDto>, IPictureService
{
    public PictureService(DataContext context) : base(context)
    {
    }
}