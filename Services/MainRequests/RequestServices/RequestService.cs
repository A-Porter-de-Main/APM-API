using APMApi.Models;
using APMApi.Models.Database.RequestModels;
using APMApi.Models.Dto.RequestDto.RequestDto;
using APMApi.Models.Exception;
using APMApi.Services.Other.BaseServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            UserId = createDto.UserId,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        });

        await _context.SaveChangesAsync();
        return request.Entity;
    }

    public override async Task<Request?> Update(Guid id, RequestUpdateDto updateDto)
    {
        var request = await GetById(id);
        if (request == null) throw new NotFoundException("Request not found");
        
        var skills = updateDto.Skills == null ? request.Skills : await _context.Skills.Where(s => updateDto.Skills.Contains(s.Id)).ToListAsync();
        
        request.Title = updateDto.Title ?? request.Title;
        request.Description = updateDto.Description ?? request.Description;
        request.Deadline = updateDto.Deadline ?? request.Deadline;
        request.UpdatedAt = DateTime.Now;
        request.Skills = skills;
        request.Pictures = updateDto.PicturesCreated ?? request.Pictures!;
        
        var result = _context.Requests.Update(request);
        await _context.SaveChangesAsync();
        
        return result.Entity;
    }

    public override Task<Request?> GetById(Guid id)
    {
        return _context.Requests
            .Include(r => r.Pictures)
            .Include(r => r.Skills)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    #endregion
    
    
}