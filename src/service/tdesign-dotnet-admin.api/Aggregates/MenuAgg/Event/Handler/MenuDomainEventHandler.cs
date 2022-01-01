namespace TDesignDotentAdmin.Aggregates.MenuAgg.Event.Handler;

public class MenuDomainEventHandler :
    INotificationHandler<ApiDeletedForMenuDomainEvent>
{
    private readonly IMenuRepository _menuRepository;
    public MenuDomainEventHandler(IMenuRepository menuRepository) => _menuRepository = menuRepository;

    /// <summary>
    /// 接口已删除
    /// </summary>
    /// <param name="notification"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task Handle(ApiDeletedForMenuDomainEvent notification, CancellationToken cancellationToken)
        => await _menuRepository.DeleteMenuApiAsync(notification.ApiId);
}
