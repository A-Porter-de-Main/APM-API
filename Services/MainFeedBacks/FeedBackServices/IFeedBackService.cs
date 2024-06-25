using APMApi.Models.Database.FeedBackModels;
using APMApi.Models.Dto.FeedBackDto.FeedBackDto;
using APMApi.Services.Other.BaseServices;

namespace APMApi.Services.MainFeedBacks.FeedBackServices;

public interface IFeedBackService : IBaseService<FeedBack, FeedBackCreateDto, FeedBackUpdateDto>
{
}