namespace TDesignDotentAdmin.Aggregates.MenuAgg.Repository;

public class MenuRepository : IMenuRepository
{
    private readonly TDesignDotnetAdminDbContext _context;
    public DbContext Context => _context;
    public MenuRepository(TDesignDotnetAdminDbContext context) => _context = context;

    public async Task AddMenuAsync(Menu menu) => await _context.Menu.AddAsync(menu);
    public async Task AddMenuApiAsync(Menu menu) => await _context.MenuApi.AddRangeAsync(menu.MenuApis);
    public async Task UpdateMenuAndApiAsync(Menu menu)
    {
        _context.Update(menu);
        var old = await _context.MenuApi.Where(x => x.MenuId == menu.Id).ToListAsync();
        if (old?.Any() is not true)
        {
            await _context.MenuApi.AddRangeAsync(menu.MenuApis);
            return;
        }
        foreach (var item in old) // 删除旧的
            if(menu.MenuApis.Any(_ => _.ApiId == item.ApiId) is false)
                _context.MenuApi.Remove(item);
        foreach (var item in menu.MenuApis) // 添加新的
            if (old.Any(_ => _.ApiId == item.ApiId) is false)
                _context.MenuApi.Add(item);
    }
    public async Task DeleteMenuAsync(long id)
    {
        var menu = await _context.Menu.FirstOrDefaultAsync(x => x.Id == id);        
        if (menu == null) return;
        _context.Menu.Remove(menu);
        menu.OnDeleted(); // 发布菜单删除事件
        var menuApis = await _context.MenuApi.Where(x => x.MenuId == menu.Id).ToListAsync();
        if (menuApis?.Any() is not true) return;
        _context.MenuApi.RemoveRange(menuApis);
    }
    public async Task DeleteMenuApiAsync(long apiId) 
        => _context.MenuApi.RemoveRange(await _context.MenuApi.Where(_ => _.ApiId == apiId).ToListAsync());
}
