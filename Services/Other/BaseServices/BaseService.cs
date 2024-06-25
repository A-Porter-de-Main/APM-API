using APMApi.Models;
using APMApi.Models.Dto;
using APMApi.Models.Exception;
using APMApi.Models.Other;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Services.Other.BaseServices;

public class BaseService<T, TCreateDto, TUpdateDto> : IBaseService<T, TCreateDto, TUpdateDto>
    where T : class, IBaseModel<T, TCreateDto, TUpdateDto>
    where TCreateDto : IDataTransferObject
    where TUpdateDto : IDataTransferObject
{
    private readonly DataContext _context;

    protected BaseService(DataContext context)
    {
        _context = context;
    }

    public virtual async Task<T> Create(TCreateDto createDto)
    {
        var entity = T.Create(createDto);
        await T.GetDbSet(_context).AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T?> Update(Guid id, TUpdateDto updateDto)
    {
        var entity = await T.GetDbSet(_context).FindAsync(id);
        if (entity == null) throw new Exception("Entity not found");
        entity.Update(updateDto);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T?> Delete(Guid id)
    {
        var entity = await T.GetDbSet(_context).FindAsync(id);
        if (entity == null) throw new NotFoundException("Entity not found");
        T.GetDbSet(_context).Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T?> GetById(Guid id)
    {
        var entity = await T.GetDbSet(_context).FindAsync(id);
        if (entity == null) throw new NotFoundException("Entity not found");
        return entity;
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        return await T.GetDbSet(_context).ToListAsync();
    }
}