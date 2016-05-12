namespace ECommerce.Core.Plugins
{
    /// <summary>
    /// 编辑界面插件属性显示接口
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// 获取或设置插件描述符
        /// </summary>
        PluginDescriptor PluginDescriptor { get; set; }

        /// <summary>
        /// 安装插件
        /// </summary>
        void Install();

        /// <summary>
        /// 卸载插件
        /// </summary>
        void Uninstall();
    }
}
