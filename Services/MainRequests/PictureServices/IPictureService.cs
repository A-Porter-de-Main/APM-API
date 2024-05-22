using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestModels.Picture;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainRequests.PictureServices;

public interface IPictureService : IBaseService<Picture, PictureCreateDto, PictureUpdateDto> { }