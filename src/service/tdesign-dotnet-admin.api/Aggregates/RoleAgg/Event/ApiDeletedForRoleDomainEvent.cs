namespace TDesignDotentAdmin.Aggregates.RoleAgg.Event;

/// <summary>
/// 接口已删除领域事件
/// </summary>
public class ApiDeletedForRoleDomainEvent : INotification
{
    public ApiDeletedForRoleDomainEvent(long apiId) => ApiId = apiId;
    public long ApiId { get; set; }
}
