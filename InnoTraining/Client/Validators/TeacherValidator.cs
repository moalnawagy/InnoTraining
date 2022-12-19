using FluentValidation;
using InnoTraining.Shared;

namespace InnoTraining.Client;

public class TeacherValidator:BasePersonValidation<Teacher>
{
    public TeacherValidator()
    {
        RuleFor(e => e.WorkingSchool).NotEmpty().MaximumLength(50);

    }
}