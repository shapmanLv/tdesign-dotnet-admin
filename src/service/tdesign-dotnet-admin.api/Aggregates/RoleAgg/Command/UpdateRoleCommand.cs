namespace TDesignDotentAdmin.Aggregates.RoleAgg.Command;

public class UpdateRoleCommand : IRequest
{
    /// <summary>
    /// 主键id
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// 角色名
    /// </summary>
    public string Name { get; set; } = "";
    /// <summary>
    /// 描述
    /// </summary>
    public string? Desc { get; set; }
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enabled { get; set; } = true;
    /// <summary>
    /// 该接口绑定的菜单
    /// </summary>
    public long[]? Menus { get; set; }
    /// <summary>
    /// 该接口绑定的接口
    /// </summary>
    public long[]? Apis { get; set; }
}
