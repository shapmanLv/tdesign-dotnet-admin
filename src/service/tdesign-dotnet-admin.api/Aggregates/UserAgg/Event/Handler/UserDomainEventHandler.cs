namespace TDesignDotentAdmin.Aggregates.UserAgg.Event.Handler;

public class UserDomainEventHandler :
    INotificationHandler<RoleDeletedForUserDomainEvent>
{
    private readonly IUserRepository _userRepository;
    public UserDomainEventHandler(IUserRepository userRepository) => _userRepository = userRepository;

    /// <summary>
    /// 角色已被删除
    /// </summary>
    /// <param name="notification"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task Handle(RoleDeletedForUserDomainEvent notification, CancellationToken cancellationToken)
        => _userRepository.DeleteUserRoleAsync(notification.RoleId);
}
