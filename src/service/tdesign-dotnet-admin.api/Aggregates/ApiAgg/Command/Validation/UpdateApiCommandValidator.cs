namespace TDesignDotentAdmin.Aggregates.ApiAgg.Command.Validation;

public class UpdateApiCommandValidator : AbstractValidator<UpdateApiCommand>
{
    public UpdateApiCommandValidator()
    {
        RuleFor(_ => _.Name).NotEmpty().NotNull();
        RuleFor(_ => _.Path).NotEmpty().NotNull();
    }
}
