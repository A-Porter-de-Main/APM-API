using APMApi.Context;
using APMApi.Models;
using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Dto.FeedBackDto.FeedBackDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainFeedBacks.FeedBackServices;

public class FeedBackService : BaseService<FeedBack, FeedBackCreateDto, FeedBackUpdateDto>, IFeedBackService
{
    public FeedBackService(DataContext context) : base(context)
    {
    }
}