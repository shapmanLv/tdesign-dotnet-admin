namespace TDesignDotentAdmin.Aggregates.UserAgg.Command.Validation;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(_ => _.Username).NotEmpty().NotNull();
        RuleFor(_ => _.Password).NotEmpty().NotNull();
        RuleFor(_ => _.PhoneNumber).NotEmpty().NotNull();
        RuleFor(_ => _.Nickname).NotEmpty().NotNull();
    }
}
