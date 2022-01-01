namespace TDesignDotentAdmin.Aggregates.RoleAgg;

public class RoleMenu : Entity
{
    /// <summary>
    /// 主键id
    /// </summary>
    [Key]
    public long Id { get; set; }
    /// <summary>
    /// 角色id
    /// </summary>
    [Required]
    public long RoleId { get; set; }
    /// <summary>
    /// 菜单id
    /// </summary>
    [Required]
    public long MenuId { get; set; }
}
