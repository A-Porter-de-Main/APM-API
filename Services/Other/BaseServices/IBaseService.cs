using APMApi.Models.Dto;
using APMApi.Models.Other;

namespace APMApi.Services.Other.BaseServices;

public interface IBaseService<T, in TCreateDto, in TUpdateDto>
    where T : class, IBaseModel<T, TCreateDto, TUpdateDto>
    where TCreateDto : IDataTransferObject
    where TUpdateDto : IDataTransferObject
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T> GetById(Guid id);
    public Task<T> Create(TCreateDto createDto);
    public Task<T> Update(Guid id, TUpdateDto updateDto);
    public Task<T> Delete(Guid id);
}