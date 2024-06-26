using System.Diagnostics;
using APMApi.Models.Dto;
using APMApi.Models.Exception;
using APMApi.Models.Other;
using APMApi.Services.Other.BaseServices;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace APMApi.Helpers;

public class ControllerBaseExtended<T, TCreateDto, TUpdateDto, TService> : ControllerBase
    where T : class, IBaseModel<T, TCreateDto, TUpdateDto>
    where TCreateDto : IDataTransferObject
    where TUpdateDto : IDataTransferObject
    where TService : IBaseService<T, TCreateDto, TUpdateDto>
{
    #region Fields

    private readonly TService _service;

    #endregion

    #region Constructor

    public ControllerBaseExtended(TService service)
    {
        _service = service;
    }

    #endregion

    #region Helpers

    protected async Task<IActionResult> TryExecuteControllerTask<TResult>(Func<Task<TResult>> action)
    {
        try
        {
            var result = await action();
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Debug.WriteLine(e.Message);
            return StatusCode(500, "Internal Server Error");
        }
    }
    
    protected void CreateCookie(string key, string value)
    {
        // var cookieToCreate = new CookieHeaderValue(key, value);
        // cookieToCreate = Request.RequestUri.Host;
        // cookieToCreate.Path = "/";
        //
        // resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
    }

    protected string ParseSqlExceptionMessage(Exception e)
    {
        var message = e.Message;
        if (e.InnerException == null) return message;
        message = e.InnerException.Message;
        if (e.InnerException.InnerException != null) message = e.InnerException.InnerException.Message;
        return message;
    }

    protected async Task<IDataTransferObject> ValidateDto(IDataTransferObject dto)
    {
        await dto.Validate();
        return dto;
    }

    #endregion

    #region Methods

    [HttpGet]
    public virtual async Task<IActionResult> GetAll()
    {
        return await TryExecuteControllerTask(async () => await _service.GetAll());
    }

    [HttpGet("{id:guid}")]
    public virtual async Task<IActionResult> GetById(Guid id)
    {
        return await TryExecuteControllerTask(async () => await _service.GetById(id));
    }

    [HttpPost]
    public virtual async Task<IActionResult> Create(TCreateDto createDto)
    {
        return await TryExecuteControllerTask(async () =>
        {
            await ValidateDto(createDto);
            return await _service.Create(createDto);
        });
    }

    [HttpPut("{id:guid}")]
    public virtual async Task<IActionResult> Update(Guid id, TUpdateDto updateDto)
    {
        return await TryExecuteControllerTask(async () =>
        {
            await ValidateDto(updateDto);
            return await _service.Update(id, updateDto);
        });
    }

    [HttpDelete("{id:guid}")]
    public virtual async Task<IActionResult> Delete(Guid id)
    {
        return await TryExecuteControllerTask(async () => await _service.Delete(id));
    }

    #endregion
}