namespace TDesignDotentAdmin.Queries.Impl;

public class MenuQuery : IMenuQuery
{
    private readonly TDesignDotnetAdminDbContext _context;
    private readonly IMapper _mapper;
    public MenuQuery(TDesignDotnetAdminDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// 用菜单数据构建一个填充到t-tree组件的数据源
    /// </summary>
    /// <returns></returns>
    public async Task<List<MenuDataTDesignTreeViewModel>?> GetMenuDataTDesignTreeAsync()
    {        
        var menudata = await _context.Menu.ToListAsync();
        Func<long, List<MenuDataTDesignTreeViewModel>?>? getNodeFunc = null; 
        getNodeFunc = (parentId) => {
            List<MenuDataTDesignTreeViewModel>? childrens = null;
            var menus = menudata.Where(_ => _.ParentId == parentId);
            if (childrens?.Any() is not true) return childrens;
            childrens = new List<MenuDataTDesignTreeViewModel>();
            foreach (var item in menus)
            {
                var node = _mapper.Map<MenuDataTDesignTreeViewModel>(item);
                node.Children = getNodeFunc?.Invoke(item.Id); // 递归遍历子节点
                childrens.Add(node);
            }
            return childrens;
        };

        return getNodeFunc(0);
    }
}
