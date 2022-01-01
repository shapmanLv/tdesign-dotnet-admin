namespace TDesignDotentAdmin.Aggregates.MenuAgg.Command.Validation;

public class UpdateMenuCommandValidator : AbstractValidator<UpdateMenuCommand>
{
    public UpdateMenuCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().NotNull();
        RuleFor(c => c.TagForVue).NotEmpty().NotNull();
    }
}
