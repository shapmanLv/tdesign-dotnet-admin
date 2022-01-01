namespace TDesignDotentAdmin.Controllers.Auth;
/// <summary>
/// 菜单
/// </summary>
[Route("api/menu")]
[ApiController]
public class MenuController : ControllerBase
{
    private readonly IMediator _mediator;
    public MenuController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// 添加菜单
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("add")]
    [Description("添加菜单")]
    public async Task<ApiRespond> Add([FromBody] AddMenuCommand command)
    {
        await _mediator.Send(command);
        return ApiRespond.SuccessResult();
    }
    /// <summary>
    /// 修改菜单
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("update")]
    [Description("修改菜单")]
    public async Task<ApiRespond> Update([FromBody] UpdateMenuCommand command)
    {
        await _mediator.Send(command);
        return ApiRespond.SuccessResult();
    }
    /// <summary>
    /// 删除菜单
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpDelete("delete/{menuId}")]
    [Description("删除菜单")]
    public async Task<ApiRespond> Delete([FromBody] DeleteMenuCommand command)
    {
        await _mediator.Send(command);
        return ApiRespond.SuccessResult();
    }
}
