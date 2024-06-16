using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestModels.Picture;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainRequests.PictureServices;

public class PictureService : BaseService<Picture, PictureCreateDto, PictureUpdateDto>, IPictureService
{
    public PictureService(DataContext context) : base(context)
    {
    }
}