namespace TDesignDotentAdmin;

/// <summary>
/// automapper 配置
/// </summary>
public class TDesignDotnetAdminAutoMapperProfile : Profile
{
    public TDesignDotnetAdminAutoMapperProfile()
    {
        CreateMap<AddMenuCommand, Menu>();
        CreateMap<UpdateMenuCommand, Menu>();
    }
}
