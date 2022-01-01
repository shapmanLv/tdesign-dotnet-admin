namespace TDesignDotentAdmin.Infrastructure.ApiRespondModel;

public record ApiRespond
{
    /// <summary>
    /// 处理结果码
    /// </summary>
    public AppDomainStatusCodeDefine.Code Code { get; set; }
    /// <summary>
    /// 此次处理结果的简单描述
    /// </summary>
    public string Msg { get; set; }

    public ApiRespond() { }
    public ApiRespond(AppDomainStatusCodeDefine.Code code) => Code = code;
    public ApiRespond(AppDomainStatusCodeDefine.Code code, string msg)
    {
        Code = code;
        Msg = msg;
    }

    /// <summary>
    /// 错误的处理结果
    /// </summary>
    /// <returns></returns>
    public static ApiRespond FailedResult()
    {
        var result = default(ApiRespond);
        result.Code = AppDomainStatusCodeDefine.Code.Success;
        result.Msg = "";
        return result;
    }
    /// <summary>
    /// 错误的处理结果
    /// </summary>
    /// <param name="msg">关于这个错误的简单描述</param>
    /// <returns></returns>
    public static ApiRespond FailedResult(string msg)
    {
        var result = default(ApiRespond);
        result.Code = AppDomainStatusCodeDefine.Code.Fail;
        result.Msg = msg;
        return result;
    }
    /// <summary>
    /// 处理成功
    /// </summary>
    /// <returns></returns>
    public static ApiRespond SuccessResult()
    {
        var result = default(ApiRespond);
        result.Code = AppDomainStatusCodeDefine.Code.Success;
        result.Msg = "";
        return result;
    }
}

public record ApiRespond<T> : ApiRespond
{
    public T Data { get; set; }
    public ApiRespond() { }
    public ApiRespond(AppDomainStatusCodeDefine.Code code) : base(code) { }
    public ApiRespond(AppDomainStatusCodeDefine.Code code, string msg) : base(code, msg) { }
    public static ApiRespond<T> SuccessResult(T data)
        => new ApiRespond<T>()
        {
            Code = AppDomainStatusCodeDefine.Code.Success,
            Msg = "",
            Data = data
        };
}