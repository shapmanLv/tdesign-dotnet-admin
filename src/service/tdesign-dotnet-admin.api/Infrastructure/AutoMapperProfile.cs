namespace TDesignDotentAdmin.Infrastructure;

/// <summary>
/// automapper 配置
/// </summary>
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddMenuCommand, Menu>();
        CreateMap<UpdateMenuCommand, Menu>();
        CreateMap<AddRoleCommand, Role>();
        CreateMap<UpdateRoleCommand, Role>();
        CreateMap<AddApiCommand, Api>();
        CreateMap<UpdateApiCommand, Api>();
        CreateMap<AddUserCommand, User>();
        CreateMap<UpdateUserCommand, User>();
        CreateMap<Menu, MenuDataTDesignTreeViewModel>()
            .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
        CreateMap<Menu, MenuWithApiTreeViewModel>();
    }
}
