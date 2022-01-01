namespace TDesignDotentAdmin.Aggregates.ApiAgg;

public class Api : Entity, IAggregateRoot
{
    public void OnDeleted()
    {
        base.AddEvent(new ApiDeletedForMenuDomainEvent(this.Id));
        base.AddEvent(new ApiDeletedForRoleDomainEvent(this.Id));
    }

    /// <summary>
    /// 主键id
    /// </summary>
    [Key]
    public long Id { get; set; }
    /// <summary>
    /// 接口名称
    /// </summary>
    [Required]
    public string Name { get; set; } = "";
    /// <summary>
    /// 接口路径
    /// </summary>
    [Required]
    public string Path { get; set; } = "";
}
