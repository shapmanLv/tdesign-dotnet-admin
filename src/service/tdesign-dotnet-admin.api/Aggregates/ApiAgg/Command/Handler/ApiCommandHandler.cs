namespace TDesignDotentAdmin.Aggregates.ApiAgg.Command.Handler;

public class ApiCommandHandler :
    IRequestHandler<AddApiCommand>,
    IRequestHandler<UpdateApiCommand>,
    IRequestHandler<DeleteApiCommand>
{
    private readonly IMapper _mapper;
    private readonly IApiRepository _apiRepository;
    public ApiCommandHandler(
        IMapper mapper,
        IApiRepository apiRepository)
    {
        _mapper = mapper;
        _apiRepository = apiRepository;
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(AddApiCommand request, CancellationToken cancellationToken)
    {
        var api = _mapper.Map<Api>(request);
        await _apiRepository.AddAsync(api);
        await _apiRepository.Context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(UpdateApiCommand request, CancellationToken cancellationToken)
    {
        var api = _mapper.Map<Api>(request);
        _apiRepository.Update(api);
        await _apiRepository.Context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(DeleteApiCommand request, CancellationToken cancellationToken)
    {
        await _apiRepository.DeleteAsync(request.Id);
        await _apiRepository.Context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
