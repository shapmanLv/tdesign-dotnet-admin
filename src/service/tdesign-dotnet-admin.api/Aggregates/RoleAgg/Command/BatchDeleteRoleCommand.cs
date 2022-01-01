namespace TDesignDotentAdmin.Aggregates.RoleAgg.Command;

public class BatchDeleteRoleCommand
{
    public BatchDeleteRoleCommand(long[] roleIds) => RoleIds = roleIds;
    public long[] RoleIds { get; set; }
}
