using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Dto.FeedBackModels.FeedBackApplication;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainFeedBacks.FeedBackApplicationServices;

public class FeedBackApplicationService : BaseService<FeedBackApplication, FeedBackApplicationCreateDto, FeedBackApplicationUpdateDto>, IFeedBackApplicationService
{
    public FeedBackApplicationService(DataContext context) : base(context) { }
    
    
}