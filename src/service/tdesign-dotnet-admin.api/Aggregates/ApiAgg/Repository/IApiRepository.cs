namespace TDesignDotentAdmin.Aggregates.ApiAgg.Repository;

public interface IApiRepository : IRepository<Api>
{
    Task AddAsync(Api api);
    void Update(Api api);
    Task DeleteAsync(long id);
}
