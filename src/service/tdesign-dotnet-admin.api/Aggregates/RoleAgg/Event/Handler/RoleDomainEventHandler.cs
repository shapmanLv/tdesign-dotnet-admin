namespace TDesignDotentAdmin.Aggregates.RoleAgg.Event.Handler;

public class RoleDomainEventHandler :
    INotificationHandler<MenuDeletedForRoleDomainEvent>,
    INotificationHandler<ApiDeletedForRoleDomainEvent>
{
    
    public Task Handle(MenuDeletedForRoleDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Handle(ApiDeletedForRoleDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
