namespace TDesignDotentAdmin.Aggregates.MenuAgg.Command.Validation;

public class AddMenuCommandValidator : AbstractValidator<AddMenuCommand>
{
    public AddMenuCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().NotNull();
        RuleFor(c => c.TagForVue).NotEmpty().NotNull();
    }
}
