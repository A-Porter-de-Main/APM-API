using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Dto.FeedBackDto.FeedBackApplicationDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainFeedBacks.FeedBackApplicationServices;

public interface IFeedBackApplicationService : IBaseService<FeedBackApplication, FeedBackApplicationCreateDto,
    FeedBackApplicationUpdateDto>
{
}