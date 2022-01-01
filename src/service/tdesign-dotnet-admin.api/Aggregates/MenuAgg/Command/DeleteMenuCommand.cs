namespace TDesignDotentAdmin.Aggregates.MenuAgg.Command;

public class DeleteMenuCommand : IRequest
{
    public DeleteMenuCommand(long id) => Id = id;
    public long Id { get; set; } 
}
