namespace TDesignDotentAdmin.DomainCore;

/// <summary>
/// 实体基类
/// </summary>
public abstract class Entity
{
    #region event source
    private List<INotification> _eventSource = new List<INotification>();
    /// <summary>
    /// 事件源
    /// </summary>
    [NotMapped]
    public IReadOnlyCollection<INotification>? EventSource => _eventSource?.AsReadOnly();

    /// <summary>
    /// 添加事件
    /// </summary>
    /// <param name="@event"></param>
    public void AddEvent(INotification @event)
    {
        _eventSource = _eventSource ?? new List<INotification>();
        _eventSource.Add(@event);
    }

    /// <summary>
    /// 移除事件
    /// </summary>
    /// <param name="@event"></param>
    public void RemoveEvent(INotification @event) => _eventSource?.Remove(@event);

    /// <summary>
    /// 清空事件
    /// </summary>
    public void ClearEvents() => _eventSource?.Clear();
    #endregion
}
