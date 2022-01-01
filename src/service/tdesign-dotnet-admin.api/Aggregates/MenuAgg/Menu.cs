namespace TDesignDotentAdmin.Aggregates.MenuAgg;

public class Menu : Entity, IAggregateRoot
{   
    /// <summary>
    /// 该菜单所绑定的接口
    /// </summary>
    [NotMapped]
    public List<MenuApi> MenuApis { get; private set; } = new List<MenuApi>();
    public void SetMenuApis(long[] apiIds)
    {
        for (int i = 0; i < apiIds.Length; i++)
            MenuApis.Add(new MenuApi { ApiId = apiIds[i], MenuId = this.Id });
    }
    public void OnDeleted() => base.AddEvent(new MenuDeletedForRoleDomainEvent(this.Id));

    /// <summary>
    /// 主键id
    /// </summary>
    [Key]
    public long Id { get; set; }
    /// <summary>
    /// 父节点id，默认0
    /// </summary>
    [Required]
    public long ParentId { get; set; } = 0;
    /// <summary>
    /// 菜单名称
    /// </summary>
    [Required]
    public string Name { get; set; } = "";
    /// <summary>
    /// 此菜单在vue中的标识
    /// </summary>
    [Required]
    public string TagForVue { get; set; } = "";
    /// <summary>
    /// 菜单类型
    /// </summary>
    [Required]
    public Enums.MenuTypeEnum MenuType { get; set; }
    /// <summary>
    /// 是否启用
    /// </summary>
    [Required]
    public bool Enabled { get; set; }
}