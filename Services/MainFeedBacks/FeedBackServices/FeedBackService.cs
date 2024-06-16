using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Dto.FeedBackModels.FeedBack;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainFeedBacks.FeedBackServices;

public class FeedBackService : BaseService<FeedBack, FeedBackCreateDto, FeedBackUpdateDto>, IFeedBackService
{
    public FeedBackService(DataContext context) : base(context)
    {
    }
}