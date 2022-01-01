namespace TDesignDotentAdmin.Aggregates.RoleAgg.Command;

public class DeleteRoleCommand : IRequest
{
    public DeleteRoleCommand(long id) => Id = id;
    public long Id { get; set; }
}
