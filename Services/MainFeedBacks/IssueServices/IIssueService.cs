using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Dto.FeedBackModels.Issue;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainFeedBacks.IssueServices;

public interface IIssueService : IBaseService<Issue, IssueCreateDto, IssueUpdateDto>
{
}