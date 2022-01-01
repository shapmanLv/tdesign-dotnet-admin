namespace TDesignDotentAdmin.Aggregates.RoleAgg;

public class Role : Entity, IAggregateRoot
{
    /// <summary>
    /// 该角色所绑定的菜单
    /// </summary>
    [NotMapped]
    public List<RoleMenu> RoleMenus { get; private set; } = new List<RoleMenu>();
    public void SetRoleMenus(long[] menuIds)
    {
        for (int i = 0; i < menuIds.Length; i++)
            RoleMenus.Add(new RoleMenu { RoleId = this.Id, MenuId = menuIds[i] });
    }
    /// <summary>
    /// 该角色绑定的接口
    /// </summary>
    [NotMapped]
    public List<RoleApi> RoleApis { get; private set; } = new List<RoleApi>();
    public void SetRoleApis(long[] apiIds)
    {
        for (int i = 0; i < apiIds.Length; i++)
            RoleApis.Add(new RoleApi { RoleId = this.Id, ApiId = apiIds[i] });
    }
    public void OnDeleted() => base.AddEvent(new RoleDeletedForUserDomainEvent(this.Id));

    /// <summary>
    /// 主键ID
    /// </summary>
    [Key]
    public long Id { get; set; }
    /// <summary>
    /// 角色名
    /// </summary>
    [Required]
    public string Name { get; set; } = "";
    /// <summary>
    /// 描述
    /// </summary>
    public string? Desc { get; set; }
    /// <summary>
    /// 是否启用
    /// </summary>
    [Required]
    public bool Enabled { get; set; } = true;   
}
