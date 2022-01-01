namespace TDesignDotentAdmin.Aggregates.UserAgg;

public class UserRole
{
    /// <summary>
    /// 主键id
    /// </summary>
    [Key]
    public long Id { get; set; }
    /// <summary>
    /// 用户id
    /// </summary>
    [Required]
    public long UserId { get; set; }
    /// <summary>
    /// 角色id
    /// </summary>
    [Required]
    public long RoleId { get; set; }
}
