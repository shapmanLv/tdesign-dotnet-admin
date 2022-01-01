namespace TDesignDotentAdmin.Aggregates.ApiAgg.Repository;

public class ApiRepository : IApiRepository
{
    private readonly TDesignDotnetAdminDbContext _context;
    public DbContext Context => _context;
    public ApiRepository(TDesignDotnetAdminDbContext context) => _context = context;

    public async Task AddAsync(Api api) => await _context.AddAsync(api);
    public void Update(Api api) => _context.Update(api);
    public async Task DeleteAsync(long id)
    {
        var entity = await _context.Api.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) return;
        _context.Remove(entity);
        entity.OnDeleted(); // 发布删除事件
    }
}
