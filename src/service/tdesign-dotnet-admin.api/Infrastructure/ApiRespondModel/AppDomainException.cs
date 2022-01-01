namespace TDesignDotentAdmin.Infrastructure.ApiRespondModel;

/// <summary>
/// 自定义业务异常
/// </summary>
public class AppDomainException : Exception
{
    /// <summary>
    /// 关于此次异常的业务代号
    /// </summary>
    public AppDomainStatusCodeDefine.Code BusinessCode { get; protected set; }
    /// <summary>
    /// 错误信息
    /// </summary>
    public string ErrorMsg { get; protected set; }
    /// <summary>
    /// 业务id，用于后面在es里通过该字段查询异常信息
    /// </summary>
    public string BusinessId { get; protected set; }

    /// <summary>
    /// 按照最终的接口响应状态码 和 自己指定的错误消息生成业务异常，并在全局异常处理里面捕获他
    /// </summary>
    /// <param name="statusCode"></param>
    public AppDomainException(AppDomainStatusCodeDefine.Code code)
    {
        this.BusinessCode = code;
        this.ErrorMsg = code.GetStatusCodeDescription();
        this.BusinessId = "";

        typeof(Exception)
            .GetField("_message", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            ?.SetValue(this, this.ErrorMsg);
    }

    /// <summary>
    /// 按照最终的接口响应状态码 和 自己指定的错误消息生成业务异常，并在全局异常处理里面捕获他
    /// </summary>
    /// <param name="statusCode"></param>
    /// <param name="businessId">业务id，用于后面在es里通过该字段查询异常信息</param>
    public AppDomainException(AppDomainStatusCodeDefine.Code code, string businessId)
    {
        this.BusinessCode = code;
        this.ErrorMsg = code.GetStatusCodeDescription();
        this.BusinessId = businessId;

        typeof(Exception)
            .GetField("_message", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            ?.SetValue(this, this.ErrorMsg);
    }

    /// <summary>
    /// 按照最终的接口响应状态码 和 自己指定的错误消息生成业务异常，并在全局异常处理里面捕获他
    /// </summary>
    /// <param name="statusCode"></param>
    /// <param name="businessId">业务id，用于后面在es里通过该字段查询异常信息</param>
    /// <param name="errorMsg">异常描述，该信息将会组织到接口响应报文中</param>
    public AppDomainException(AppDomainStatusCodeDefine.Code code, string businessId, string errorMsg)
        : base(errorMsg)
    {
        this.BusinessCode = code;
        this.ErrorMsg = errorMsg;
        this.BusinessId = businessId;
    }

    /// <summary>
    /// 按照最终的接口响应状态码 和 自己指定的错误消息生成业务异常，并在全局异常处理里面捕获他
    /// </summary>
    /// <param name="statusCode"></param>
    /// <param name="businessId">业务id，用于后面在es里通过该字段查询异常信息</param>
    /// <param name="errorMsg">异常描述，该信息将会组织到接口响应报文中</param>
    /// <param name="innerException"></param>
    public AppDomainException(AppDomainStatusCodeDefine.Code code, string businessId, string errorMsg, Exception innerException)
        : base(errorMsg, innerException)
    {
        this.BusinessCode = code;
        this.ErrorMsg = errorMsg;
        this.BusinessId = businessId;
    }
}

