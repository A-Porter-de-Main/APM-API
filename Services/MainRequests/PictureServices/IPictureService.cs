using APMApi.Models.Database;
using APMApi.Models.Dto.RequestDto.PictureDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainRequests.PictureServices;

public interface IPictureService : IBaseService<Picture, PictureCreateDto, PictureUpdateDto>
{
}