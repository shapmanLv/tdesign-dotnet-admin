namespace TDesignDotentAdmin.Aggregates.UserAgg.Event;

/// <summary>
/// 角色已删除事件
/// </summary>
public class RoleDeletedForUserDomainEvent : INotification
{
    public RoleDeletedForUserDomainEvent(long roleId) => RoleId = roleId;
    public long RoleId { get; set; }
}
