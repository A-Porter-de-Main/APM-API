using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Dto.FeedBackModels.FeedBackApplication;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainFeedBacks.FeedBackApplicationServices;

public interface IFeedBackApplicationService : IBaseService<FeedBackApplication, FeedBackApplicationCreateDto,
    FeedBackApplicationUpdateDto>
{
}