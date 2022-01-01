namespace TDesignDotentAdmin.DomainCore.Behaviors;
public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        _logger.LogDebug("----- 准备执行领域命令：{CommandName} - 参数为：({@Command})", request.GetGenericTypeName(), request);
        var response = await next();
        _logger.LogDebug("----- 领域命令 {CommandName} 执行结束 - 返回结果: {@Response}", request.GetGenericTypeName(), response);

        return response;
    }
}

