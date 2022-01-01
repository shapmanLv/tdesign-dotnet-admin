namespace TDesignDotentAdmin.Aggregates.MenuAgg;

public class MenuApi : Entity
{
    /// <summary>
    /// 主键id
    /// </summary>
    [Key]
    public long Id { get; set; }
    /// <summary>
    /// 接口id
    /// </summary>
    public long ApiId { get; set; }
    /// <summary>
    /// 菜单id
    /// </summary>
    [Required]
    public long MenuId { get; set; }    
}
