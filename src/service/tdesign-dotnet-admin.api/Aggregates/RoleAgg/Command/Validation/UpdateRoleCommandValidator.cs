namespace TDesignDotentAdmin.Aggregates.RoleAgg.Command.Validation;

public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        base.RuleFor(_ => _.Name).NotNull().NotEmpty();
    }
}
