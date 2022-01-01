namespace TDesignDotentAdmin.Aggregates.UserAgg.Command;

public class UpdateUserCommand : IRequest
{
    /// <summary>
    /// 主键id
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// 账户
    /// </summary>
    public string Username { get; set; } = "";
    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; } = "";
    /// <summary>
    /// 昵称
    /// </summary>
    public string Nickname { get; set; } = "";
    /// <summary>
    /// 是否启用该账户
    /// </summary>
    public bool Enabled { get; set; } = true;
    /// <summary>
    /// 是否是管理员
    /// </summary>
    public bool IsAdmin { get; set; } = false;
    /// <summary>
    /// 手机号
    /// </summary>
    public string PhoneNumber { get; set; } = "";
    /// <summary>
    /// 邮箱
    /// </summary>
    public string Email { get; set; } = "";
    /// <summary>
    /// 绑定的角色
    /// </summary>
    public long[]? Roles { get; set; }
}
