using FluentValidation;

namespace APMApi.Models.Dto;

public interface IDataTransferObject
{
    public Task Validate();

    public class Validator : AbstractValidator<IDataTransferObject>
    {
    }
}