namespace TDesignDotentAdmin.Aggregates.UserAgg;

public class User : Entity, IAggregateRoot
{
    /// <summary>
    /// 该菜单所绑定的接口
    /// </summary>
    [NotMapped]
    public List<UserRole> UserRoles { get; private set; } = new List<UserRole>();
    public void SetUserRoles(long[] roleIds)
    {
        for (int i = 0; i < roleIds.Length; i++)
            UserRoles.Add(new UserRole { RoleId = roleIds[i], UserId = this.Id });
    }
    public void OnDeleted() { }

    /// <summary>
    /// 主键id
    /// </summary>
    [Key]
    public long Id { get; set; }
    /// <summary>
    /// 账户
    /// </summary>
    [Required]
    public string Username { get; set; } = "";
    /// <summary>
    /// 密码
    /// </summary>
    [Required]
    public string Password { get; set; } = "";
    /// <summary>
    /// 昵称
    /// </summary>
    [Required]
    public string Nickname { get; set; } = "";
    /// <summary>
    /// 是否启用该账户
    /// </summary>
    [Required]
    public bool Enabled { get; set; } = true;
    /// <summary>
    /// 是否是管理员
    /// </summary>
    [Required]
    public bool IsAdmin { get; set; } = false;
    /// <summary>
    /// 手机号
    /// </summary>
    [Required]
    public string PhoneNumber { get; set; } = "";
    /// <summary>
    /// 邮箱
    /// </summary>
    public string Email { get; set; } = "";
    /// <summary>
    /// 上一次登陆时间
    /// </summary>
    public DateTime? LastLoginTime { get; set; }
    /// <summary>
    /// 上一次登陆IP
    /// </summary>
    public string LastLoginIp { get; set; } = "";
}
