namespace TDesignDotentAdmin.Aggregates.ApiAgg.Command;

public class UpdateApiCommand : IRequest
{
    /// <summary>
    /// 主键id
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// 接口名称
    /// </summary>
    public string Name { get; set; } = "";
    /// <summary>
    /// 接口路径
    /// </summary>
    public string Path { get; set; } = "";
}
