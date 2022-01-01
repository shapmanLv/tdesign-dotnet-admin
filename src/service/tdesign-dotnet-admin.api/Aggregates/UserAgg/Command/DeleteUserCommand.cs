namespace TDesignDotentAdmin.Aggregates.UserAgg.Command;

public class DeleteUserCommand : IRequest
{
    public DeleteUserCommand(long id) => Id = id;
    public long Id { get; set; }
}
