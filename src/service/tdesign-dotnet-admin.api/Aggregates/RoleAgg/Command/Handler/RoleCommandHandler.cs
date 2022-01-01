namespace TDesignDotentAdmin.Aggregates.RoleAgg.Command.Handler;

public class RoleCommandHandler :
    IRequestHandler<AddRoleCommand>,
    IRequestHandler<UpdateRoleCommand>,
    IRequestHandler<DeleteRoleCommand>,
    IRequestHandler<BatchDeleteRoleCommand>
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
    public async Task<Unit> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Role>(request);
        await _roleRepository.AddRoleAsync(entity);
        using (var transaction = await _roleRepository.Context.Database.BeginTransactionAsync())
        {
            try
            {
                await _roleRepository.Context.SaveChangesAsync();
                entity.SetRoleMenus(request.Menus ?? new long[0]);
                entity.SetRoleApis(request.Apis ?? new long[0]);
                await _roleRepository.AddRoleMenuAndApiAsync(entity);
                await _roleRepository.Context.SaveChangesAsync();
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
    public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Role>(request);
        entity.SetRoleApis(request.Apis ?? new long[0]);
        entity.SetRoleMenus(request.Menus ?? new long[0]);
        await _roleRepository.UpdateRoleAsync(entity);
        await _roleRepository.Context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        await _roleRepository.DeleteRoleAsync(request.RoleId);
        await _roleRepository.Context.SaveChangesAsync();
        return Unit.Value;
    }
    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(BatchDeleteRoleCommand request, CancellationToken cancellationToken)
    {
        for (int i = 0; i < request.RoleIds.Length; i++)
            await _roleRepository.DeleteRoleAsync(request.RoleIds[i]);
        await _roleRepository.Context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
