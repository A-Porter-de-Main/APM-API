using APMApi.Context;
using APMApi.Models;
using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Dto.FeedBackDto.FeedBackApplicationDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainFeedBacks.FeedBackApplicationServices;

public class FeedBackApplicationService :
    BaseService<FeedBackApplication, FeedBackApplicationCreateDto, FeedBackApplicationUpdateDto>,
    IFeedBackApplicationService
{
    public FeedBackApplicationService(DataContext context) : base(context)
    {
    }
}