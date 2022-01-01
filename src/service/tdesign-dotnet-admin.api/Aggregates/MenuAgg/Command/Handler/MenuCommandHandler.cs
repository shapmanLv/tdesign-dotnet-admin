namespace TDesignDotentAdmin.Aggregates.MenuAgg.Command.Handler;

public class MenuCommandHandler : 
    IRequestHandler<AddMenuCommand>,
    IRequestHandler<UpdateMenuCommand>,
    IRequestHandler<DeleteMenuCommand>
{
    private readonly IMenuRepository _menuRepository;
    private IMapper _mapper;
    public MenuCommandHandler(
        IMenuRepository menuRepository,
        IMapper mapper)
    {
        _menuRepository = menuRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// 添加菜单
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(AddMenuCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Menu>(request);
        await _menuRepository.AddMenuAsync(entity);
        using(var transaction = await _menuRepository.Context.Database.BeginTransactionAsync())
        {
            try
            {
                await _menuRepository.Context.SaveChangesAsync();
                entity.SetMenuApis(request.Apis ?? new long[0]);
                await _menuRepository.AddMenuApiAsync(entity);
                await _menuRepository.Context.SaveChangesAsync();
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
    /// 修改菜单
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Menu>(request);
        entity.SetMenuApis(request.Apis ?? new long[0]);
        await _menuRepository.UpdateMenuAndApiAsync(entity);
        await _menuRepository.Context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
    /// <summary>
    /// 删除菜单
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
    {
        await _menuRepository.DeleteMenuAsync(request.Id);
        await _menuRepository.Context.SaveChangesAsync();
        return Unit.Value;
    }    
}
