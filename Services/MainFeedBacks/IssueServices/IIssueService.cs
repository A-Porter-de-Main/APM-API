using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Dto.FeedBackDto.IssueDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainFeedBacks.IssueServices;

public interface IIssueService : IBaseService<Issue, IssueCreateDto, IssueUpdateDto>
{
}