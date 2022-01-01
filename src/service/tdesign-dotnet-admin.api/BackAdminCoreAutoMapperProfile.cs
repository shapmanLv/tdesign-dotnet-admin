namespace TDesignDotentAdmin;

/// <summary>
/// automapper 配置
/// </summary>
public class BackAdminCoreAutoMapperProfile : Profile
{
    public BackAdminCoreAutoMapperProfile()
    {
        CreateMap<AddMenuCommand, Menu>();
        CreateMap<UpdateMenuCommand, Menu>();
    }
}
