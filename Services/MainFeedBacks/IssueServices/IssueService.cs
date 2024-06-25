using APMApi.Models;
using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Dto.FeedBackDto.IssueDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainFeedBacks.IssueServices;

public class IssueService : BaseService<Issue, IssueCreateDto, IssueUpdateDto>, IIssueService
{
    public IssueService(DataContext context) : base(context)
    {
    }
}