using FactoryPulse.Application.DTOs;
using FluentValidation;

namespace FactoryPulse.Application.Validators;

public class TelemetryRequestValidator : AbstractValidator<TelemetryRequest>
{
    public TelemetryRequestValidator()
    {
        RuleFor(x => x.MachineId)
            .NotEmpty();

        RuleFor(x => x.Temperature)
            .GreaterThanOrEqualTo(-50)
            .LessThanOrEqualTo(200);

        RuleFor(x => x.Pressure)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.RPM)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.PiecesProduced)
            .GreaterThanOrEqualTo(0);
    }
}