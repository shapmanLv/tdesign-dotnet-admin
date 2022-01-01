namespace TDesignDotentAdmin.Aggregates.RoleAgg.Command.Validation;

public class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
{
    public AddRoleCommandValidator()
    {
        base.RuleFor(_ => _.Name).NotNull().NotEmpty();
    }
}
