namespace TDesignDotentAdmin.Queries;

public interface IMenuQuery
{
    /// <summary>
    /// 用菜单数据构建一个填充到t-tree组件的数据源
    /// </summary>
    /// <returns></returns>
    Task<List<MenuDataTDesignTreeViewModel>?> GetMenuDataTDesignTreeAsync();
    /// <summary>
    /// 获取由菜单和接口数据组成的树
    /// </summary>
    /// <returns></returns>
    Task<List<MenuWithApiTreeViewModel>?> GetMenuWithApiTreeAsync();
}
