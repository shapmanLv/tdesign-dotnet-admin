namespace TDesignDotentAdmin.Aggregates.UserAgg.Repository;

public interface IUserRepository : IRepository<User>
{
    Task AddUserAsync(User user);
    Task AddUserRoleAsync(User user);
    Task UpdateUserAndRoleAsync(User user);
    Task DeleteUserAsync(long id);
    Task DeleteUserRoleAsync(long roleId);
}
