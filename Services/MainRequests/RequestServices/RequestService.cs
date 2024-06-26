using APMApi.Models;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestDto.RequestDto;
using APMApi.Services.Other.BaseServices;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Services.MainRequests.RequestServices;

public class RequestService : BaseService<Request, RequestCreateDto, RequestUpdateDto>, IRequestService
{
    #region Fields

    private readonly DataContext _context;

    #endregion

    #region Constructror

    public RequestService(DataContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public override async Task<Request> Create(RequestCreateDto createDto)
    {
        var status = await _context.Statuses.FirstOrDefaultAsync(s => s.Name == "open");
        var skills = await _context.Skills.Where(s => createDto.Skills.Contains(s.Id)).ToListAsync();
        
        var request = await _context.Requests.AddAsync(new Request
        {
            Title = createDto.Title,
            Description = createDto.Description,
            StatusId = status?.Id,
            Status = status == null ? new Status
            {
                Name = "open"
            } : null,
            Pictures = createDto.PicturesCreated,
            Skills = skills,
            Deadline = createDto.Deadline,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        });

        await _context.SaveChangesAsync();
        return request.Entity;
    }

    #endregion
    
    
}