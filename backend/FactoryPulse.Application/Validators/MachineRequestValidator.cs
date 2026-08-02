using FactoryPulse.Application.DTOs;
using FluentValidation;

namespace FactoryPulse.Application.Validators;

public class MachineRequestValidator : AbstractValidator<MachineRequest>
{
    public MachineRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Sector)
            .NotEmpty()
            .MaximumLength(100);
    }
}