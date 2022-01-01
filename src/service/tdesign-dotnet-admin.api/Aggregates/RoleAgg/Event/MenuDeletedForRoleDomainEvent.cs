namespace TDesignDotentAdmin.Aggregates.RoleAgg.Event;

/// <summary>
/// 菜单已删除领域事件
/// </summary>
public class MenuDeletedForRoleDomainEvent : INotification
{
    public MenuDeletedForRoleDomainEvent(long menuId) => MenuId = menuId;
    public long MenuId { get; set; }
}
