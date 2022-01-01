namespace TDesignDotentAdmin.Aggregates.ApiAgg.Command;

public class DeleteApiCommand : IRequest
{
    public DeleteApiCommand(long id) => Id = id;
    public long Id { get; set; }    
}
