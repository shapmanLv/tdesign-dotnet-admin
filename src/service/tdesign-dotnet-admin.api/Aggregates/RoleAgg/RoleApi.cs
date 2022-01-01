namespace TDesignDotentAdmin.Aggregates.RoleAgg;

public class RoleApi : Entity
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
    /// 接口id
    /// </summary>
    [Required]
    public long ApiId { get; set; }
}
