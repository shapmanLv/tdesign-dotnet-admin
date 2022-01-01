namespace TDesignDotentAdmin.Aggregates.ApiAgg.Command;

public class AddApiCommand : IRequest
{
    /// <summary>
    /// 接口名称
    /// </summary>
    public string Name { get; set; } = "";
    /// <summary>
    /// 接口路径
    /// </summary>
    public string Path { get; set; } = "";
}
