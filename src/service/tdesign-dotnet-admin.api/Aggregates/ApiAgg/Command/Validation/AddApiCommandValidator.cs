namespace TDesignDotentAdmin.Aggregates.ApiAgg.Command.Validation;

public class AddApiCommandValidator : AbstractValidator<AddApiCommand>
{
    public AddApiCommandValidator()
    {
        RuleFor(_ => _.Name).NotEmpty().NotNull();
        RuleFor(_ => _.Path).NotEmpty().NotNull();
    }
}
