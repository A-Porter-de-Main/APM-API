using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Dto.FeedBackModels.Issue;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainFeedBacks.IssueServices;

public class IssueService : BaseService<Issue, IssueCreateDto, IssueUpdateDto>, IIssueService
{
    public IssueService(DataContext context) : base(context)
    {
    }
}