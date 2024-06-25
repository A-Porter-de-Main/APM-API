using APMApi.Context;
using APMApi.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace APMApi.Models.Other;

public interface IBaseModel<T, in TCreateDto, in TUpdateDto>
    where T : class
    where TCreateDto : IDataTransferObject
    where TUpdateDto : IDataTransferObject
{
    public static abstract T Create(TCreateDto createDto);
    public T Update(TUpdateDto updateDto);
    public static abstract DbSet<T> GetDbSet(DataContext context);
}