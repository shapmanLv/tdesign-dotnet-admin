namespace TDesignDotentAdmin.Aggregates.UserAgg.Command.Validation;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    public AddUserCommandValidator()
    {
        RuleFor(_ => _.Username).NotEmpty().NotNull();
        RuleFor(_ => _.Password).NotEmpty().NotNull();
        RuleFor(_ => _.PhoneNumber).NotEmpty().NotNull();
        RuleFor(_ => _.Nickname).NotEmpty().NotNull();
    }
}