namespace TDesignDotentAdmin.Infrastructure.ViewModels;
/// <summary>
/// 菜单数据按照 t-tree 的格式要求而制成的视图模型
/// </summary>
public record MenuDataTDesignTreeViewModel
{
    public string Label { get; set; } = "";
    public long Value { get; set; }
    public List<MenuDataTDesignTreeViewModel>? Children { get; set; }
}
