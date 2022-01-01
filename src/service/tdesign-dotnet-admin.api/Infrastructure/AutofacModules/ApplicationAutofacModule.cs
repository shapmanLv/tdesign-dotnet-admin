namespace TDesignDotentAdmin.Infrastructure.AutofacModules;

public class ApplicationAutofacModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IMenuQuery).GetTypeInfo().Assembly)
            .Where(t => t.Name.EndsWith("Query"))
            .AsImplementedInterfaces();
    }
}
