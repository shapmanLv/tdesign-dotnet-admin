namespace TDesignDotentAdmin.Aggregates.RoleAgg.Repository;

public class RoleRepository : IRoleRepository
{
    private readonly BackAdminCoreDbContext _context;
    public DbContext Context => _context;
    public RoleRepository(BackAdminCoreDbContext context) => _context = context;

    public async Task AddRoleAsync(Role role) => await _context.AddAsync(role);
    public async Task AddRoleMenuAndApiAsync(Role role)
    {
        await _context.RoleMenu.AddRangeAsync(role.RoleMenus);
        await _context.RoleApi.AddRangeAsync(role.RoleApis);
    }
    public async Task UpdateRoleAsync(Role role)
    {
        _context.Update(role);
        var oldMenus = await _context.RoleMenu.Where(x => x.RoleId == role.Id).ToListAsync();
        if (oldMenus?.Any() is not true)
        {
            await _context.RoleMenu.AddRangeAsync(role.RoleMenus);
            return;
        }
        foreach (var item in oldMenus) // 删除旧的
            if (role.RoleMenus.Any(_ => _.MenuId == item.MenuId) is false)
                _context.RoleMenu.Remove(item);
        foreach (var item in role.RoleMenus) // 添加新的
            if (oldMenus.Any(_ => _.MenuId == item.MenuId) is false)
                _context.RoleMenu.Add(item);

        var oldApis = await _context.RoleApi.Where(x => x.RoleId == role.Id).ToListAsync();
        if (oldApis?.Any() is not true)
        {
            await _context.RoleApi.AddRangeAsync(role.RoleApis);
            return;
        }
        foreach (var item in oldApis) // 删除旧的
            if (role.RoleApis.Any(_ => _.ApiId == item.ApiId) is false)
                _context.RoleApi.Remove(item);
        foreach (var item in role.RoleApis) // 添加新的
            if (oldApis.Any(_ => _.ApiId == item.ApiId) is false)
                _context.RoleApi.Add(item);
    }
    public async Task DeleteRoleAsync(long id)
    {
        var role = await _context.Role.FirstOrDefaultAsync(x => x.Id == id);
        if (role == null) return;
        _context.Role.Remove(role);
        role.OnDeleted(); // 发布菜单删除事件
        var roleApis = await _context.RoleApi.Where(x => x.RoleId == role.Id).ToListAsync();
        if (roleApis?.Any() is true) _context.RoleApi.RemoveRange(roleApis);
        var roleMenus = await _context.RoleMenu.Where(x => x.RoleId != role.Id).ToListAsync();
        if(roleMenus?.Any() is true) _context.RoleMenu.RemoveRange(roleMenus);
    }
    public async Task DeleteRoleMenuAsync(long menuId)
        => _context.RemoveRange(await _context.RoleMenu.Where(_ => _.MenuId == menuId).ToListAsync());
    public async Task DeleteRoleApiAsync(long apiId)
        => _context.RemoveRange(await _context.RoleApi.Where(_ => _.ApiId == apiId).ToListAsync());
}
