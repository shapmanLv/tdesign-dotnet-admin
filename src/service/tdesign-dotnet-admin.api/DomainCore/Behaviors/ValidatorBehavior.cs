namespace TDesignDotentAdmin.DomainCore.Behaviors;

public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<ValidatorBehavior<TRequest, TResponse>> _logger;
    private readonly IValidator<TRequest>[] _validators;

    public ValidatorBehavior(IValidator<TRequest>[] validators, ILogger<ValidatorBehavior<TRequest, TResponse>> logger)
    {
        _validators = validators;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var typeName = request.GetGenericTypeName();

        _logger.LogDebug("----- 准备对领域命令 {CommandType} 进行参数校验", typeName);

        var failures = _validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .ToList();

        if (failures.Any())
        {
            throw new Exception(
                $"领域命令 {typeof(TRequest).Name} 在接受 {string.Join('；', this._validators.Select(_ => _.GetType().Name))} 的校验时，校验并未通过，错误详情为：{string.Join(' ', failures.Select((_, count) => $"{count + 1}、{_.ErrorMessage}"))}");
        }

        return await next();
    }
}