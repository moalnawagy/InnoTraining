using FluentValidation;
using InnoTraining.Shared;
namespace InnoTraining.Client;


public class BasePersonValidation<T>:BaseSettingValidation<T> where T:BasePerson
{
    public BasePersonValidation()
    {
        RuleFor(e => e.Mobile).NotEmpty().Length(11, 11);
        RuleFor(e => e.BirthDate).NotEmpty();
        RuleFor(e => e.Age).NotEmpty().GreaterThan(18);
    }
    
}
