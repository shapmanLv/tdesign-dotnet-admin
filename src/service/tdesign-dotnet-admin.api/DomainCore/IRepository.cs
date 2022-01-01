namespace TDesignDotentAdmin.DomainCore;

/// <summary>
/// 仓储基接口
/// </summary>
/// <typeparam name="TAggregateRoot">聚合根</typeparam>
public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
{
    /// <summary>
    /// 工作单元
    /// </summary>
    DbContext Context { get; }
}
