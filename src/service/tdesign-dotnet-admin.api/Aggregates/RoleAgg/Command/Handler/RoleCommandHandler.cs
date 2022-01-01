namespace TDesignDotentAdmin.Aggregates.RoleAgg.Command.Handler;

public class RoleCommandHandler :
    IRequestHandler<AddRoleCommand>,
    IRequestHandler<UpdateRoleCommand>,
    IRequestHandler<DeleteRoleCommand>
{
    private readonly IMapper _mapper;
    private readonly IRoleRepository _roleRepository;
    public RoleCommandHandler(
        IMapper mapper,
        IRoleRepository roleRepository)
    {
        _mapper = mapper;
        _roleRepository = roleRepository;
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<Unit> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
