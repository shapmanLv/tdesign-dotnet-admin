namespace TDesignDotentAdmin.Aggregates.UserAgg.Command.Handler;

public class UserCommandHandler :
    IRequestHandler<AddUserCommand>,
    IRequestHandler<UpdateUserCommand>,
    IRequestHandler<DeleteUserCommand>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    public UserCommandHandler(
        IMapper mapper,
        IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<User>(request);
        await _userRepository.AddUserAsync(entity);
        using (var transaction = await _userRepository.Context.Database.BeginTransactionAsync())
        {
            try
            {
                await _userRepository.Context.SaveChangesAsync();
                entity.SetUserRoles(request.Roles ?? new long[0]);
                await _userRepository.AddUserRoleAsync(entity);
                await _userRepository.Context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        return Unit.Value;
    }
    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<User>(request);
        entity.SetUserRoles(request.Roles ?? new long[0]);
        await _userRepository.UpdateUserAndRoleAsync(entity);
        await _userRepository.Context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.DeleteUserAsync(request.Id);
        await _userRepository.Context.SaveChangesAsync();
        return Unit.Value;
    }
}
