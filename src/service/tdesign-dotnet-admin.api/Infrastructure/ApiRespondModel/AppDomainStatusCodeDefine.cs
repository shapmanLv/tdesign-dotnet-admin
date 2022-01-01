namespace TDesignDotentAdmin.Infrastructure.ApiRespondModel;

/// <summary>
/// app 状态码定义
/// </summary>
public static class AppDomainStatusCodeDefine
{
    /// <summary>
    /// 系统自定义业务状态码
    /// </summary>
    public enum Code
    {
        [Description("success")]
        Success = 0,
        [Display(Name = "request fail")]
        Fail = 2,
        [Display(Name = "server internal error")]
        Error = 500,
    }

    private static Type type = typeof(AppDomainStatusCodeDefine.Code);

    /// <summary>
    /// 获取相关状态码所对应的描述
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static string GetStatusCodeDescription(this Code code)
        => (type?.GetField(code.ToString())?.GetCustomAttributes(typeof(DescriptionAttribute), false)[0] as DescriptionAttribute)?.Description ?? "";
}