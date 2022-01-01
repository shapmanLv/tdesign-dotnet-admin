namespace TDesignDotentAdmin.Controllers.Auth;
/// <summary>
/// 菜单
/// </summary>
[Route("api/menu")]
[ApiController]
public class MenuController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMenuQuery _menuQuery;
    public MenuController(IMediator mediator, IMenuQuery menuQuery)
    {
        _mediator = mediator;
        _menuQuery = menuQuery;
    }

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
    public async Task<ApiRespond> Delete(long menuId)
    {
        await _mediator.Send(new DeleteMenuCommand(menuId));
        return ApiRespond.SuccessResult();
    }
    /// <summary>
    /// 用菜单数据构建一个填充到t-tree组件的数据源
    /// </summary>
    /// <returns></returns>
    [HttpGet("getMenuDataTDesignTree")]
    [Description("获取使用菜单数据制成的t-tree组件数据源")]
    public async Task<ApiRespond<List<MenuDataTDesignTreeViewModel>?>> GetMenuDataTDesignTree()
        => ApiRespond.SuccessResult(await _menuQuery.GetMenuDataTDesignTreeAsync());
    public async Task<ApiRespond>
}
