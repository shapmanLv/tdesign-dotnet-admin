namespace TDesignDotentAdmin.Aggregates.UserAgg.Repository;

public class UserRepository : IUserRepository
{
    private readonly BackAdminCoreDbContext _context;
    public DbContext Context => _context;
    public UserRepository(BackAdminCoreDbContext context) => _context = context;

    public async Task AddUserAsync(User user) => await _context.User.AddAsync(user);
    public async Task AddUserRoleAsync(User user) => await _context.UserRole.AddRangeAsync(user.UserRoles);
    public async Task UpdateUserAndRoleAsync(User user)
    {
        _context.Update(user);
        var old = await _context.UserRole.Where(x => x.UserId == user.Id).ToListAsync();
        if (old?.Any() is not true)
        {
            await _context.UserRole.AddRangeAsync(user.UserRoles);
            return;
        }
        foreach (var item in old) // 删除旧的
            if (user.UserRoles.Any(_ => _.RoleId == item.RoleId) is false)
                _context.UserRole.Remove(item);
        foreach (var item in user.UserRoles) // 添加新的
            if (old.Any(_ => _.RoleId == item.RoleId) is false)
                _context.UserRole.Add(item);
    }
    public async Task DeleteUserAsync(long id)
    {
        var user = await _context.User.FirstOrDefaultAsync(_ => _.Id == id);
        if(user == null) return;
        _context.User.Remove(user);
        user.OnDeleted(); // 发布用户删除事件
        var userRoles = await _context.UserRole.Where(_ => _.UserId == id).ToListAsync();
        if (userRoles?.Any() is not true) return;
        _context.UserRole.RemoveRange(userRoles);
    }
    public async Task DeleteUserRoleAsync(long roleId)
        => _context.UserRole.RemoveRange(await _context.UserRole.Where(_ => _.RoleId == roleId).ToListAsync());
}
