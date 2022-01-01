namespace TDesignDotentAdmin.Aggregates.MenuAgg.Event;

/// <summary>
/// 接口已删除领域事件
/// </summary>
public class ApiDeletedForMenuDomainEvent : INotification
{
    public ApiDeletedForMenuDomainEvent(long apiId) => ApiId = apiId;
    public long ApiId { get; set; }
}
