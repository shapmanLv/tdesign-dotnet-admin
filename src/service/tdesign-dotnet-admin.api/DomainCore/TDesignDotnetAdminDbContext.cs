namespace TDesignDotentAdmin.DomainCore;

public class TDesignDotnetAdminDbContext : DbContext
{
    private readonly IMediator _mediator;
    public TDesignDotnetAdminDbContext(DbContextOptions<TDesignDotnetAdminDbContext> options)
     : base(options)
    { }
    public TDesignDotnetAdminDbContext(DbContextOptions<TDesignDotnetAdminDbContext> options, IMediator mediator)
        : base(options)
        => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator), "");

    /// <summary>
    /// 重写save changes方法，在写入数据库之前订阅每个实体里event source所储存的所有发布的事件
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        /* 收集所有被修改数据的实体的领域事件 */
        var domainEntities = this.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.EventSource != null && x.Entity.EventSource.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.EventSource)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearEvents()); // 清空所有实体的领域事件

        foreach (var domainEvent in domainEvents)
            await this._mediator.Publish(domainEvent); // 发布领域事件

        return await base.SaveChangesAsync(cancellationToken); // 继续执行工作单元
    }

    public DbSet<Menu> Menu { get; set; }
    public DbSet<MenuApi> MenuApi { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<RoleMenu> RoleMenu { get; set; }
    public DbSet<RoleApi> RoleApi { get; set; }
    public DbSet<Api> Api { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
}
