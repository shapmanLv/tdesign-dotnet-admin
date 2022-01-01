namespace TDesignDotentAdmin.Aggregates.RoleAgg.Command;

public class DeleteRoleCommand : IRequest
{
    public DeleteRoleCommand(long roleId) => RoleId = roleId;
    public long RoleId { get; set; }
}
