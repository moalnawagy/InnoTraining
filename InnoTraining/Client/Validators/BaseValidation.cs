using InnoTraining.Shared;

namespace InnoTraining.Client;
using FluentValidation;


public class BaseValidation<T>: AbstractValidator<T> where T:BaseEntity
{
    public BaseValidation()
    {
        RuleFor(e => e.Id).NotNull();
    }
}