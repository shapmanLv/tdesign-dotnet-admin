namespace TDesignDotentAdmin.Aggregates.RoleAgg.Repository;

public interface IRoleRepository : IRepository<Role>
{
    Task AddRoleAsync(Role role);
    Task AddRoleMenuAndApiAsync(Role role);    
    Task UpdateRoleAsync(Role role);
    Task DeleteRoleAsync(long id);
    Task DeleteRoleMenuAsync(long menuId);
    Task DeleteRoleApiAsync(long apiId);
}
