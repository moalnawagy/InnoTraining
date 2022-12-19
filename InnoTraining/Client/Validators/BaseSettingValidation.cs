using FluentValidation;
using InnoTraining.Shared;

namespace InnoTraining.Client;

public class BaseSettingValidation<T>:BaseValidation<T> where T:BaseSettingEntity
{
    public BaseSettingValidation()
    {
        RuleFor(e => e.Name).NotEmpty().MaximumLength(50);

    }
}