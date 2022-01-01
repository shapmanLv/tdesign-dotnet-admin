namespace TDesignDotentAdmin.Aggregates.MenuAgg.Command;

public record AddMenuCommand : IRequest
{
    /// <summary>
    /// 父节点id，默认0
    /// </summary>
    public long? ParentId { get; set; }
    /// <summary>
    /// 菜单名称
    /// </summary>
    public string Name { get; set; } = "";
    /// <summary>
    /// 此菜单在vue中的标识
    /// </summary>
    public string TagForVue { get; set; } = "";
    /// <summary>
    /// 菜单类型
    /// </summary>
    public Enums.MenuTypeEnum MenuType { get; set; }
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enabled { get; set; }
    /// <summary>
    /// 要绑定的接口
    /// </summary>
    public long[]? Apis { get; set; }
}
