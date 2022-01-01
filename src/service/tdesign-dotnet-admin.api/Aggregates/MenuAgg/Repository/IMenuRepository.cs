namespace TDesignDotentAdmin.Aggregates.MenuAgg.Repository;

public interface IMenuRepository : IRepository<Menu>
{
    Task AddMenuAsync(Menu menu);
    Task AddMenuApiAsync(Menu menu);
    Task UpdateMenuAndApiAsync(Menu menu);
    Task DeleteMenuAsync(long id);
    Task DeleteMenuApiAsync(long apiId);
}
